using System.Collections.Generic;

namespace Quickstarts.DataAccessServer
{
    public class UnderlyingSystemConfig
    {
        public List<string> Segments { get; set; }
        public List<string> Blocks { get; set; }
        public IDictionary<string, BlockType> BlockTypes { get; set; }
    }


    public class BlockType
    {
        public string Name { get; set; }
        public List<BlockTag> Tags { get; set; }
    }


    public class BlockTag
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string TagType { get; set; }
        public string Units { get; set; }
        public bool Writable { get; set; }
    }

}
