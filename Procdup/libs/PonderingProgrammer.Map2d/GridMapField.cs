using System.Collections.Generic;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridMapField
    {
        public GridCoordinatePair Coordinates { get; }
        public Dictionary<int, List<IGridFeatureObject>> FeatureLayers { get; } = new Dictionary<int, List<IGridFeatureObject>>();
        
        public GridMapField(GridCoordinatePair coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
