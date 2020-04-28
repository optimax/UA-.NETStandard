using System.Collections.Generic;
using Opc.Ua;

namespace DataAccessClient
{
    public class OpcNodeInfo
    {
        public string Path => Parent != null ? $"{Parent.Path}/{DisplayName}": DisplayName;
        public string DisplayName => Target?.DisplayName.ToString();
        public string Id => Target?.NodeId.ToString();
        public string Type => Target?.TypeDefinition.Identifier.ToString();

        public List<OpcAttributeInfo> Attributes { get; }
        public List<OpcNodeInfo> Nodes { get; }

        private OpcNodeInfo Parent;
        private ReferenceDescription Target;

        public OpcNodeInfo(OpcNodeInfo parent, ReferenceDescription target)
        {
            Nodes = new List<OpcNodeInfo>();
            Attributes = new List<OpcAttributeInfo>();
            this.Target = target;
            this.Parent = parent;
        }
    }
}
