using System.Collections.Generic;
using GridMath;

namespace GridMap
{
    public interface IGridMap
    {
        GridBoundingBox Bounds { get; }
        IReadOnlyList<IFeature> Features { get; }
        bool AddFeature(IFeature feature);
        bool RemoveFeature(IFeature feature);
    }
}