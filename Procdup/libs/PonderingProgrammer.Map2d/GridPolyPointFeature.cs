using System.Collections.Generic;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridPolyPointFeature : IGridFeatureObject
    {
        public GridPolyPointFeature(FeatureType featureType, GridPolyPoint polyPoint)
        {
            FeatureType = featureType;
            Shape = polyPoint;
        }
        
        public GridPolyPointFeature(FeatureType featureType, IEnumerable<GridCoordinatePair> coordinates)
        {
            FeatureType = featureType;
            Shape = new GridPolyPoint(coordinates);
        }
        
        public IGridShape Shape { get; }
        public FeatureType FeatureType { get; }

        public GridPolyPoint PolyPoint => (GridPolyPoint) Shape;
    }
}
