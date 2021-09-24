using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public interface IGridFeatureObject
    {
        public IGridShape Shape { get; }
        FeatureType FeatureType { get; }
    }
}
