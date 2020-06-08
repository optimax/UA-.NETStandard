using System;
using System.Collections.Generic;
using System.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using Quickstarts;

namespace DataAccessClient
{
    public class OpcAddressSpaceInfo
    {
        public string ServerUri => session?.ConfiguredEndpoint.EndpointUrl.ToString();

        public DateTimeOffset DumpStamp => DateTime.Now;

        public string RootPath { get; set; } = "\\";

        public List<OpcNodeInfo> RootNodes { get; }

        public int NodeCount { get; set; }

        internal readonly Session session;

        public OpcAddressSpaceInfo(Session session)
        {
            RootNodes = new List<OpcNodeInfo>();
            this.session = session;
        }


        public OpcAddressSpaceInfo Populate(NodeId sourceId, string rootPath, Action<int> progress = null)
        {
            RootPath = "\\" + rootPath;
            NodeCount = 0;
            PopulateBranch(null, sourceId, RootNodes, progress);
            return this;
        }


        public void PopulateBranch(OpcNodeInfo parent, NodeId sourceId, List<OpcNodeInfo> nodes, Action<int> progress)
        {
            nodes.Clear();

            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            // find all nodes organized by the node
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = sourceId;
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);
            nodesToBrowse.Add(nodeToBrowse2);

            // fetch references from the server
            var references = FormUtils.Browse(session, nodesToBrowse, false)
                .OrderBy( d => d.DisplayName).ToList();

            if (references == null || !references.Any())
                return;

            // process results
            for (int i = 0; i < references.Count; i++)
            {
                var target = references[i];
                var childNode = new OpcNodeInfo(parent, target);
                nodes.Add(childNode);
                NodeCount++;
                progress?.Invoke(NodeCount);
                PopulateBranch(childNode, (NodeId)target.NodeId, childNode.Nodes, progress);
                PopulateAttributes((NodeId)target.NodeId, childNode.Attributes);
            }
        }


        private void PopulateAttributes(NodeId sourceId, List<OpcAttributeInfo> attributes)
        {
            attributes.Clear();

            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            // attempt to read all possible attributes.
            for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = sourceId;
                nodeToRead.AttributeId = ii;
                nodesToRead.Add(nodeToRead);
            }

            int startOfProperties = nodesToRead.Count;

            // find all of the pror of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = 0;
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);

            // fetch property references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(session, nodesToBrowse, false);

            if (references == null)
            {
                return;
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                // ignore external references.
                if (references[ii].NodeId.IsAbsolute)
                {
                    continue;
                }

                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                nodeToRead.AttributeId = Attributes.Value;
                nodesToRead.Add(nodeToRead);
            }

            // read all values.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            // process results.
            for (int ii = 0; ii < results.Count; ii++)
            {
                string name = null;
                string datatype = null;
                string value = null;

                // process attribute value.
                if (ii < startOfProperties)
                {
                    // ignore attributes which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                    {
                        continue;
                    }

                    // get the name of the attribute.
                    name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        datatype = Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                        value = Utils.Format("{0}", results[ii].StatusCode);
                    }

                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                        datatype = typeInfo.BuiltInType.ToString();

                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            datatype += "[]";
                        }
                        value = Utils.Format("{0}", results[ii].Value);
                    }
                }

                // process property value.
                else
                {
                    // ignore properties which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                    {
                        continue;
                    }

                    // get the name of the property.
                    name = Utils.Format("{0}", references[ii - startOfProperties]);

                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        datatype = String.Empty;
                        value = Utils.Format("{0}", results[ii].StatusCode);
                    }

                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                        datatype = typeInfo.BuiltInType.ToString();

                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            datatype += "[]";
                        }

                        value = Utils.Format("{0}", results[ii].Value);
                    }
                }

                // add the attribute name/value to the list 
                var item = new OpcAttributeInfo(name, datatype, value);
                attributes.Add(item);
            }
        }

    }
}
