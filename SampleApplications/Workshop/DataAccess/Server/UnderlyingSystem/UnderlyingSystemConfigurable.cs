using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Opc.Ua;

namespace Quickstarts.DataAccessServer
{

    public class UnderlyingSystemConfigurable : IUnderlyingSystem
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnderlyingSystem"/> class.
        /// </summary>
        public UnderlyingSystemConfigurable(string configFileName)
        {
            m_blocks = new Dictionary<string, UnderlyingSystemBlock>();
            LoadConfig(configFileName);
        }


        private void LoadConfig(string configFileName)
        {
            if (!File.Exists(configFileName))
                throw new Exception($"Configuration file '{configFileName}' does not exist.");

            //var ser = JsonConvert.SerializeObject(conf,Formatting.Indented);
            //File.WriteAllText(@"C:\temp\serialization.json",ser);
            //var des = File.ReadAllText(@"C:\temp\serialization.json");
            //var result = JsonConvert.DeserializeObject<UnderlyingSystemConfig>(des);

            var json = File.ReadAllText(configFileName);
            var config = JsonConvert.DeserializeObject<UnderlyingSystemConfig>(json);

            BlockPathDatabase = config.Segments;
            BlockDatabase = config.Blocks;
            BlockTypeDatabase = config.BlockTypes;

        }

        #endregion


        #region Private Fields


        /// <summary>
        /// A database which stores all known block paths.
        /// </summary>
        /// <remarks>
        /// These are hardcoded for an example but the real data could come from a DB,
        /// a file or any other system accessed with a non-UA API.
        /// 
        /// The name of the block is the final path element.
        /// The same block can have many paths.
        /// Each preceding element is a segment.
        /// </remarks>
        private List<string> BlockPathDatabase;


        /// <summary>
        /// A database which stores all known blocks.
        /// </summary>
        /// <remarks>
        /// These are hardcoded for an example but the real data could come from a DB,
        /// a file or any other system accessed with a non-UA API.
        /// 
        /// The name of the block is the first element.
        /// The type of block is the second element.
        /// </remarks>
        private List<string> BlockDatabase;


        /// <summary>
        /// A database that stores block type definitions along with their tags
        /// </summary>
        private IDictionary<string, BlockType> BlockTypeDatabase;



        private object m_lock = new object();

        private Dictionary<string, UnderlyingSystemSegment> m_segments;
        private Dictionary<string, UnderlyingSystemBlock> m_blocks;

        private Timer m_simulationTimer;
        private long m_simulationCounter;
        private Opc.Ua.Test.DataGenerator m_generator;

        #endregion


        #region Public Methods

        /// <summary>
        /// Finds the segments belonging to the specified segment.
        /// </summary>
        /// <param name="segmentPath">The path to the segment to search.</param>
        /// <returns>The list of segments found. Null if the segment path does not exist.</returns>
        public IList<UnderlyingSystemSegment> FindSegments(string segmentPath)
        {
            segmentPath = segmentPath ?? String.Empty;

            lock (m_lock)
            {
                Dictionary<string, UnderlyingSystemSegment> segments = new Dictionary<string, UnderlyingSystemSegment>();

                // find all block paths that start with the specified segment.
                int length = segmentPath.Length;

                for (int ii = 0; ii < BlockPathDatabase.Count; ii++)
                {
                    string blockPath = BlockPathDatabase[ii];

                    // check for segment path prefix in block path.
                    if (length > 0)
                    {
                        if (length >= blockPath.Length || blockPath[length] != '/')
                        {
                            continue;
                        }

                        if (!blockPath.StartsWith(segmentPath))
                        {
                            continue;
                        }

                        blockPath = blockPath.Substring(length + 1);
                    }

                    // extract segment name.
                    int index = blockPath.IndexOf('/');

                    if (index >= 0)
                    {
                        string segmentName = blockPath.Substring(0, index);

                        if (!segments.ContainsKey(segmentName))
                        {
                            string segmentId = segmentName;

                            if (!String.IsNullOrEmpty(segmentPath))
                            {
                                segmentId = segmentPath;
                                segmentId += "/";
                                segmentId += segmentName;
                            }

                            UnderlyingSystemSegment segment = new UnderlyingSystemSegment();

                            segment.Id = segmentId;
                            segment.Name = segmentName;
                            segment.SegmentType = null;

                            segments.Add(segmentName, segment);
                        }
                    }
                }

                // return list.
                return new List<UnderlyingSystemSegment>(segments.Values);
            }
        }


        /// <summary>
        /// Returns the segment
        /// </summary>
        /// <param name="segmentPath">The path to the segment.</param>
        /// <returns>The segment. Null if the segment path does not exist.</returns>
        public UnderlyingSystemSegment FindSegment(string segmentPath)
        {
            lock (m_lock)
            {
                Debug.WriteLine($"UNDERLYING: {nameof(FindSegment)}");

                // check for invalid path.
                if (string.IsNullOrEmpty(segmentPath))
                {
                    return null;
                }

                // extract the seqment name from the path.
                string segmentName = segmentPath;

                int index = segmentPath.LastIndexOf('/');

                if (index != -1)
                {
                    segmentName = segmentName.Substring(index + 1);
                }

                if (string.IsNullOrEmpty(segmentName))
                {
                    return null;
                }

                // see if there is a block path that includes the segment.
                index = segmentPath.Length;

                for (int ii = 0; ii < BlockPathDatabase.Count; ii++)
                {
                    string blockPath = BlockPathDatabase[ii];

                    if (index >= blockPath.Length || blockPath[index] != '/')
                    {
                        continue;
                    }

                    // segment found - return the info.
                    if (blockPath.StartsWith(segmentPath))
                    {
                        UnderlyingSystemSegment segment = new UnderlyingSystemSegment();

                        segment.Id = segmentPath;
                        segment.Name = segmentName;
                        segment.SegmentType = null;

                        return segment;
                    }
                }

                return null;
            }
        }


        
        //private static string SegmentNameFromPath(string segmentPath)
        //{
        //    string segmentName = segmentPath;
        //    int index = segmentPath.LastIndexOf('/');
        //    if (index != -1)
        //        segmentName = segmentName.Substring(index + 1);
        //    if (string.IsNullOrEmpty(segmentName))
        //        return null;
        //    return segmentName;
        //}


        //private static UnderlyingSystemSegment CreateSegment(string segmentPath, string name)
        //{
        //    var segmentName = name;
        //    string segmentId = segmentName;
        //    if (!String.IsNullOrEmpty(segmentPath))
        //    {
        //        segmentId = segmentPath;
        //        segmentId += "/";
        //        segmentId += segmentName;
        //    }

        //    var segment = new UnderlyingSystemSegment {Id = "", Name = "", SegmentType = null,};
        //    segment.Id = segmentId;
        //    segment.Name = segmentName;
        //    segment.SegmentType = null;
        //    return segment;
        //}


        /// <summary>
        /// Finds the blocks belonging to the specified segment.
        /// </summary>
        /// <param name="segmentPath">The path to the segment to search.</param>
        /// <returns>The list of blocks found. Null if the segment path does not exist.</returns>
        public IList<string> FindBlocks(string segmentPath)
        {
            lock (m_lock)
            {
                // check for invalid path.
                if (String.IsNullOrEmpty(segmentPath))
                {
                    segmentPath = String.Empty;
                }

                List<string> blocks = new List<string>();

                // look up the segment in the "DB".
                int length = segmentPath.Length;

                for (int ii = 0; ii < BlockPathDatabase.Count; ii++)
                {
                    string blockPath = BlockPathDatabase[ii];

                    // check for segment path prefix in block path.
                    if (length > 0)
                    {
                        if (length >= blockPath.Length || blockPath[length] != '/')
                        {
                            continue;
                        }

                        if (!blockPath.StartsWith(segmentPath))
                        {
                            continue;
                        }

                        blockPath = blockPath.Substring(length + 1);
                    }

                    // check if there are no more segments in the path.
                    int index = blockPath.IndexOf('/');

                    if (index == -1)
                    {
                        blockPath = blockPath.Substring(index + 1);

                        if (!blocks.Contains(blockPath))
                        {
                            blocks.Add(blockPath);
                        }
                    }
                }

                return blocks;
            }
        }


        /// <summary>
        /// Finds the parent segment for the specified segment.
        /// </summary>
        /// <param name="segmentPath">The segment path.</param>
        /// <returns>The segment path for the the parent.</returns>
        public UnderlyingSystemSegment FindParentForSegment(string segmentPath)
        {
            lock (m_lock)
            {
                Debug.WriteLine($"UNDERLYING: {nameof(FindParentForSegment)}");
                // check for invalid segment.
                UnderlyingSystemSegment segment = FindSegment(segmentPath);

                if (segment == null)
                {
                    return null;
                }

                // check for root segment.
                int index = segmentPath.LastIndexOf('/');

                if (index == -1)
                {
                    return null;
                }

                // construct the parent.
                UnderlyingSystemSegment parent = new UnderlyingSystemSegment();

                parent.Id = segmentPath.Substring(0, index);
                parent.SegmentType = null;

                index = parent.Id.LastIndexOf('/');

                if (index == -1)
                {
                    parent.Name = parent.Id;
                }
                else
                {
                    parent.Name = parent.Id.Substring(0, index);
                }


                return parent;
            }
        }


        /// <summary>
        /// Finds a block.
        /// </summary>
        /// <param name="blockId">The block identifier.</param>
        /// <returns>The block.</returns>
        public UnderlyingSystemBlock FindBlock(string blockId)
        {
            UnderlyingSystemBlock block = null;

            lock (m_lock)
            {
                Debug.WriteLine($"UNDERLYING: {nameof(FindBlock)}");

                // check for invalid name.
                if (String.IsNullOrEmpty(blockId))
                {
                    return null;
                }

                // look for cached block.
                if (m_blocks.TryGetValue(blockId, out block))
                {
                    return block;
                }

                // lookup block in database.
                string blockTypeName = LookupBlockTypeName(blockId);
                // block not found.
                if (blockTypeName == null)
                    return null;
                

                // create a new block.
                block = new UnderlyingSystemBlock();

                // create the block.
                block.Id = blockId;
                block.Name = blockId;
                block.BlockType = blockTypeName;

                m_blocks.Add(blockId, block);


                if (!BlockTypeDatabase.TryGetValue(block.BlockType, out var blockType))
                    throw new Exception($"Block Type {blockTypeName} is not defined.");


                // add the tags based on the block type.
                // note that the block and tag types used here are types defined by the underlying system.
                // the node manager will need to map these types to UA defined types.

                foreach (var tag in blockType.Tags)
                {
                    var dataType = ParseUnderlyingDataType(tag.DataType);
                    var tagType = ParseUnderlyingTagType(tag.TagType);
                    block.CreateTag(tag.Name, dataType, tagType, tag.Units, tag.Writable);
                }

                //switch (block.BlockType)
                //{
                //    case "FlowSensor":
                //    {
                //        block.CreateTag("Measurement", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Analog,
                //            "liters/sec", false);
                //        block.CreateTag("Online", UnderlyingSystemDataType.Integer1, UnderlyingSystemTagType.Digital,
                //            null, false);
                //        break;
                //    }

                //    case "LevelSensor":
                //    {
                //        block.CreateTag("Measurement", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Analog,
                //            "liters", false);
                //        block.CreateTag("Online", UnderlyingSystemDataType.Integer1, UnderlyingSystemTagType.Digital,
                //            null, false);
                //        break;
                //    }

                //    case "Controller":
                //    {
                //        block.CreateTag("SetPoint", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal,
                //            null, true);
                //        block.CreateTag("Measurement", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal,
                //            null, false);
                //        block.CreateTag("Output", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal, null,
                //            false);
                //        block.CreateTag("Status", UnderlyingSystemDataType.Integer4, UnderlyingSystemTagType.Enumerated,
                //            null, false);
                //        break;
                //    }

                //    case "CustomController":
                //    {
                //        block.CreateTag("Input1", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal, null,
                //            true);
                //        block.CreateTag("Input2", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal, null,
                //            true);
                //        block.CreateTag("Input3", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal, null,
                //            true);
                //        block.CreateTag("Output", UnderlyingSystemDataType.Real4, UnderlyingSystemTagType.Normal, null,
                //            false);
                //        break;
                //    }
                //}
            }

            // return the new block.
            return block;
        }

        
        /// <summary>
        /// Finds the segments for block.
        /// </summary>
        /// <param name="blockId">The block id.</param>
        /// <returns>The list of segments.</returns>
        public IList<UnderlyingSystemSegment> FindSegmentsForBlock(string blockId)
        {
            lock (m_lock)
            {
                Debug.WriteLine($"UNDERLYING: {nameof(FindSegmentsForBlock)}");


                // check for invalid path.
                if (String.IsNullOrEmpty(blockId))
                {
                    return null;
                }

                List<UnderlyingSystemSegment> segments = new List<UnderlyingSystemSegment>();

                // look up the segment in the block path database.
                int length = blockId.Length;

                for (int ii = 0; ii < BlockPathDatabase.Count; ii++)
                {
                    string blockPath = BlockPathDatabase[ii];

                    if (length >= blockPath.Length || blockPath[blockPath.Length - length] != '/')
                    {
                        continue;
                    }

                    if (!blockPath.EndsWith(blockId))
                    {
                        continue;
                    }

                    string segmentPath = blockPath.Substring(0, blockPath.Length - length - 1);

                    // construct segment.
                    UnderlyingSystemSegment segment = new UnderlyingSystemSegment();

                    segment.Id = segmentPath;
                    segment.SegmentType = null;

                    int index = segmentPath.LastIndexOf('/');

                    if (index == -1)
                    {
                        segment.Name = segmentPath;
                    }
                    else
                    {
                        segment.Name = segmentPath.Substring(0, index);
                    }

                    segments.Add(segment);
                }

                return segments;
            }
        }

        #endregion

        #region Helpers


        private UnderlyingSystemTagType ParseUnderlyingTagType(string tagTagType)
        {
            if (!Enum.TryParse<UnderlyingSystemTagType>(tagTagType, out var dataType))
                return UnderlyingSystemTagType.Normal;
            return dataType;
        }


        private UnderlyingSystemDataType ParseUnderlyingDataType(string tagDataType)
        {
            if (!Enum.TryParse<UnderlyingSystemDataType>(tagDataType, out var dataType))
                return UnderlyingSystemDataType.Undefined;
            return dataType;
        }


        private string LookupBlockTypeName(string blockId)
        {
            string blockType = null;
            int length = blockId.Length;

            for (int ii = 0; ii < BlockDatabase.Count; ii++)
            {
                blockType = BlockDatabase[ii];

                if (length >= blockType.Length || blockType[length] != '/')
                {
                    continue;
                }

                if (blockType.StartsWith(blockId))
                {
                    blockType = blockType.Substring(length + 1);
                    break;
                }

                blockType = null;
            }

            return blockType;
        }


        #endregion


        #region Simulation

        /// <summary>
        /// Starts a simulation which causes the tag states to change.
        /// </summary>
        /// <remarks>
        /// This simulation randomly activates the tags that belong to the blocks.
        /// Once an tag is active it has to be acknowledged and confirmed.
        /// Once an tag is confirmed it go to the inactive state.
        /// If the tag stays active the severity will be gradually increased.
        /// </remarks>
        public void StartSimulation()
        {
            lock (m_lock)
            {
                if (m_simulationTimer != null)
                {
                    m_simulationTimer.Dispose();
                    m_simulationTimer = null;
                }

                m_generator = new Opc.Ua.Test.DataGenerator(null);
                m_simulationTimer = new Timer(DoSimulation, null, 1000, 1000);
            }
        }


        /// <summary>
        /// Stops the simulation.
        /// </summary>
        public void StopSimulation()
        {
            lock (m_lock)
            {
                if (m_simulationTimer != null)
                {
                    m_simulationTimer.Dispose();
                    m_simulationTimer = null;
                }
            }
        }


        /// <summary>
        /// Simulates a block by updating the state of the tags belonging to the condition.
        /// </summary>
        private void DoSimulation(object state)
        {
            try
            {
                // get the list of blocks.
                List<UnderlyingSystemBlock> blocks = null;

                lock (m_lock)
                {
                    m_simulationCounter++;
                    blocks = new List<UnderlyingSystemBlock>(m_blocks.Values);
                }

                // run simulation for each block.
                for (int ii = 0; ii < blocks.Count; ii++)
                {
                    blocks[ii].DoSimulation(m_simulationCounter, ii, m_generator);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error running simulation for system");
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
        }

        #endregion
    }
}

