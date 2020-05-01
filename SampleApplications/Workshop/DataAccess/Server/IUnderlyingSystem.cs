using System;
using System.Collections.Generic;

namespace Quickstarts.DataAccessServer
{
    public interface IUnderlyingSystem: IDisposable
    {
        IList<string> FindBlocks(string segmentPath);
        UnderlyingSystemSegment FindSegment(string segmentPath);
        IList<UnderlyingSystemSegment> FindSegments(string segmentPath);
        UnderlyingSystemSegment FindParentForSegment(string segmentPath);
        UnderlyingSystemBlock FindBlock(string blockId);
        IList<UnderlyingSystemSegment> FindSegmentsForBlock(string blockId);

        void StartSimulation();
        void StopSimulation();
    }
}
