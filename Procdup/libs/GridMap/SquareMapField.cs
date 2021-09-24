using GridMath;

namespace GridMap
{
    public class SquareMapField
    {
        public SquareMapField(GridCoordinatePair coordinates, Feature area)
        {
            Coordinates = coordinates;
            Area = area;
        }

        public GridCoordinatePair Coordinates { get; }
        public Feature Area { get; }
    }
}