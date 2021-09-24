using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridRectFeature : IGridFeatureObject
    {
        public GridRectFeature(FeatureType featureType, GridRectangle rect)
        {
            FeatureType = featureType;
            Shape = rect;
        }

        public GridRectFeature(FeatureType featureType, GridBoundingBox box)
        {
            FeatureType = featureType;
            Shape = new GridRectangle(box);
        }

        public IGridShape Shape { get; }
        public FeatureType FeatureType { get; }

        public GridRectangle Rectangle => (GridRectangle) Shape;
    }
}
