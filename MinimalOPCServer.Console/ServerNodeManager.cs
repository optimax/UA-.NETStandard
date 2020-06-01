using System;
using System.Collections.Generic;
using System.Threading;
using Opc.Ua;
using Opc.Ua.Server;

namespace MinimalOPCServer
{
    internal class ServerNodeManager : CustomNodeManager2
    {
        #region Private Fields

        private readonly ServerConfiguration _configuration;
        private List<BaseDataVariableState> _dynamicNodes;
        private Timer _simulationTimer;
        private bool _simulationEnabled = true;
        private ushort _simulationInterval = 3000;
        private Opc.Ua.Test.DataGenerator _generator;

        #endregion


        public ServerNodeManager(IServerInternal server, ApplicationConfiguration configuration):
            base(server, configuration, Namespaces.NodeMinimalServer)
        {
            SystemContext.NodeIdFactory = this;

            // get the configuration for the node manager.
            _configuration = configuration.ParseExtension<ServerConfiguration>();

            // use suitable defaults if no configuration exists.
            if (_configuration == null)
            {
                _configuration = new ServerConfiguration();
            }

            _dynamicNodes = new List<BaseDataVariableState>();
        }


        public override NodeId New(ISystemContext context, NodeState node)
        {
            if (node is BaseInstanceState instance && instance.Parent != null)
            {
                if (instance.Parent.NodeId.Identifier is string id)
                {
                    return new NodeId(id + "_" + instance.SymbolicName, instance.Parent.NodeId.NamespaceIndex);
                }
            }

            return node.NodeId;
        }


        // any initialization required before the address space can be used.
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out IList<IReference> references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }


                FolderState root = null;
                try
                {
                    root = CreateFolder(null, "MinimalOpcServer", "MinimalOpcServer");
                    root.AddReference(ReferenceTypes.Organizes, true, ObjectIds.ObjectsFolder);
                    references.Add(new NodeStateReference(ReferenceTypes.Organizes, false, root.NodeId));
                    root.EventNotifier = EventNotifiers.SubscribeToEvents;
                    List<BaseDataVariableState> variables = new List<BaseDataVariableState>();

                    //#region Scalar
                    //FolderState scalarFolder = CreateFolder(root, "Scalar", "Scalar");
                    //BaseDataVariableState scalarInstructions = CreateVariable(scalarFolder, "Scalar_Instructions", "Scalar_Instructions", DataTypeIds.String, ValueRanks.Scalar);
                    //scalarInstructions.Value = "A library of Read/Write Variables of all supported data-types.";
                    //variables.Add(scalarInstructions);
                    //#endregion

                    //#region Scalar
                    //FolderState scalarFolder = CreateFolder(root, "Scalar", "Scalar");
                    //BaseDataVariableState scalarInstructions = CreateVariable(scalarFolder, "Scalar_Instructions", "Scalar_Instructions", DataTypeIds.String, ValueRanks.Scalar);
                    //scalarInstructions.Value = "A library of Read/Write Variables of all supported data-types.";
                    //variables.Add(scalarInstructions);
                    //#endregion

                    //#region Scalar_Static
                    //FolderState staticFolder = CreateFolder(root, "Scalar_Static", "Scalar_Static");
                    //const string scalarStatic = "Scalar_Static_";
                    //variables.Add(CreateVariable(staticFolder, scalarStatic + "Boolean", "Boolean", DataTypeIds.Boolean, ValueRanks.Scalar));
                    //variables.Add(CreateVariable(staticFolder, scalarStatic + "Byte", "Byte", DataTypeIds.Byte, ValueRanks.Scalar));
                    //variables.Add(CreateVariable(staticFolder, scalarStatic + "ByteString", "ByteString", DataTypeIds.ByteString, ValueRanks.Scalar));
                    //variables.Add(CreateVariable(staticFolder, scalarStatic + "DateTime", "DateTime", DataTypeIds.DateTime, ValueRanks.Scalar));
                    //variables.Add(CreateVariable(staticFolder, scalarStatic + "Double", "Double", DataTypeIds.Double, ValueRanks.Scalar));
                    //BaseDataVariableState decimalVariable = CreateVariable(staticFolder, scalarStatic + "Decimal", "Decimal", DataTypeIds.DecimalDataType, ValueRanks.Scalar);
                    //// Set an arbitrary precision decimal value.
                    //BigInteger largeInteger = BigInteger.Parse("1234567890123546789012345678901234567890123456789012345");
                    //DecimalDataType decimalValue = new DecimalDataType
                    //{
                    //    Scale = 100,
                    //    Value = largeInteger.ToByteArray()
                    //};
                    //decimalVariable.Value = decimalValue;
                    //variables.Add(decimalVariable);
                    //#endregion

                    //#region Scalar_Simulation
                    //FolderState simulationFolder = CreateFolder(root, "Scalar_Smulation", "Simulation");
                    //const string scalarSimulation = "Scalar_Simulation_";
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "Boolean", "Boolean", DataTypeIds.Boolean, ValueRanks.Scalar);
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "Byte", "Byte", DataTypeIds.Byte, ValueRanks.Scalar);
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "ByteString", "ByteString", DataTypeIds.ByteString, ValueRanks.Scalar);
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "DateTime", "DateTime", DataTypeIds.DateTime, ValueRanks.Scalar);
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "Double", "Double", DataTypeIds.Double, ValueRanks.Scalar);
                    //CreateDynamicVariable(simulationFolder, scalarSimulation + "Duration", "Duration", DataTypeIds.Duration, ValueRanks.Scalar);

                    //BaseDataVariableState intervalVariable = CreateVariable(simulationFolder, scalarSimulation + "Interval", "Interval", DataTypeIds.UInt16, ValueRanks.Scalar);
                    //intervalVariable.Value = m_simulationInterval;
                    //intervalVariable.OnSimpleWriteValue = OnWriteInterval;

                    //BaseDataVariableState enabledVariable = CreateVariable(simulationFolder, scalarSimulation + "Enabled", "Enabled", DataTypeIds.Boolean, ValueRanks.Scalar);
                    //enabledVariable.Value = m_simulationEnabled;
                    //enabledVariable.OnSimpleWriteValue = OnWriteEnabled;
                    //#endregion
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Error creating the address space.");
                }

                AddPredefinedNode(SystemContext, root);
                _simulationTimer = new Timer(DoSimulation, null, 3000, 1000);
            }
        }


        // Frees any resources allocated for the address space.
        public override void DeleteAddressSpace()
        {
            lock (Lock)
            {
                // TBD
            }
        }


        // Returns a unique handle for the node.
        protected override NodeHandle GetManagerHandle(ServerSystemContext context, NodeId nodeId,
            IDictionary<NodeId, NodeState> cache)
        {
            lock (Lock)
            {
                // quickly exclude nodes that are not in the namespace. 
                if (!IsNodeIdInNamespace(nodeId))
                {
                    return null;
                }

                if (!PredefinedNodes.TryGetValue(nodeId, out NodeState node))
                {
                    return null;
                }

                NodeHandle handle = new NodeHandle {NodeId = nodeId, Node = node, Validated = true};
                return handle;
            }
        }


        // Verifying if the specified node exists.
        protected override NodeState ValidateNode(
            ServerSystemContext context,
            NodeHandle handle,
            IDictionary<NodeId, NodeState> cache)
        {
            // not valid if no root.
            if (handle == null)
            {
                return null;
            }

            // check if previously validated.
            if (handle.Validated)
            {
                return handle.Node;
            }

            // TBD

            return null;
        }


        // Creates a new folder.
        private FolderState CreateFolder(NodeState parent, string path, string name)
        {
            FolderState folder = new FolderState(parent) {
                SymbolicName = name,
                ReferenceTypeId = ReferenceTypes.Organizes,
                TypeDefinitionId = ObjectTypeIds.FolderType,
                NodeId = new NodeId(path, NamespaceIndex),
                BrowseName = new QualifiedName(path, NamespaceIndex),
                DisplayName = new LocalizedText("en", name),
                WriteMask = AttributeWriteMask.None,
                UserWriteMask = AttributeWriteMask.None,
                EventNotifier = EventNotifiers.None
            };
            if (parent != null)
            {
                parent.AddChild(folder);
            }

            return folder;
        }


        //simulate the node attribute values to change it continuously
        private void DoSimulation(object state)
        {
            try
            {
                lock (Lock)
                {
                    foreach (BaseDataVariableState variable in _dynamicNodes)
                    {
                        variable.Value = GetNewValue(variable);
                        variable.Timestamp = DateTime.UtcNow;
                        variable.ClearChangeMasks(SystemContext, false);
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error doing simulation.");
            }
        }


        //geting new value for the variable
        private object GetNewValue(BaseVariableState variable)
        {
            if (_generator == null)
            {
                _generator = new Opc.Ua.Test.DataGenerator(null) {BoundaryValueFrequency = 0};
            }

            object value = null;
            int retryCount = 0;
            while (value == null && retryCount < 10)
            {
                value = _generator.GetRandom(variable.DataType, variable.ValueRank, new uint[] {10}, Server.TypeTree);
                retryCount++;
            }

            //System.Console.WriteLine("into generationg new value   "+ value);
            return value;
        }


        // Createing a new variable in the node.
        private BaseDataVariableState CreateVariable(NodeState parent, string path, string name, NodeId dataType,
            int valueRank)
        {
            BaseDataVariableState variable = new BaseDataVariableState(parent) {
                SymbolicName = name,
                ReferenceTypeId = ReferenceTypes.Organizes,
                TypeDefinitionId = VariableTypeIds.BaseDataVariableType,
                NodeId = new NodeId(path, NamespaceIndex),
                BrowseName = new QualifiedName(path, NamespaceIndex),
                DisplayName = new LocalizedText("en", name),
                WriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description,
                UserWriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description,
                DataType = dataType,
                ValueRank = valueRank,
                AccessLevel = AccessLevels.CurrentReadOrWrite,
                UserAccessLevel = AccessLevels.CurrentReadOrWrite,
                Historizing = false
            };
            variable.Value = GetNewValue(variable);
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.UtcNow;

            if (valueRank == ValueRanks.OneDimension)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> {0});
            }
            else if (valueRank == ValueRanks.TwoDimensions)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> {0, 0});
            }

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }


        //creating cariable dynamicly( changing value of the variable dynamicly)
        private BaseDataVariableState CreateDynamicVariable(NodeState parent, string path, string name, NodeId dataType,
            int valueRank)
        {
            BaseDataVariableState variable = CreateVariable(parent, path, name, dataType, valueRank);
            _dynamicNodes.Add(variable);
            return variable;
        }


        //writing value on specific intervals
        private ServiceResult OnWriteInterval(ISystemContext context, NodeState node, ref object value)
        {
            try
            {
                _simulationInterval = (UInt16)value;
                if (_simulationEnabled)
                {
                    _simulationTimer.Change(100, (int)_simulationInterval);
                }

                return ServiceResult.Good;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error writing Interval variable.");
                return ServiceResult.Create(e, StatusCodes.Bad, "Error writing Interval variable.");
            }
        }


        //enabling write service
        private ServiceResult OnWriteEnabled(ISystemContext context, NodeState node, ref object value)
        {
            try
            {
                _simulationEnabled = (bool)value;

                if (_simulationEnabled)
                {
                    _simulationTimer.Change(100, (int)_simulationInterval);
                }
                else
                {
                    _simulationTimer.Change(100, 0);
                }

                return ServiceResult.Good;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error writing Enabled variable.");
                return ServiceResult.Create(e, StatusCodes.Bad, "Error writing Enabled variable.");
            }
        }
    }
}
