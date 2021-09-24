using NetTopologySuite.Geometries;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public class MapGeometryFactory
    {
        private GeometryFactory _factory = new GeometryFactory();
        
        public Polygon MapCellToPolygon<T>(GridMapField gridMapField, double scale)
        {
            return _factory.CreatePolygon(CellCorners(gridMapField, scale));
        }

        private Coordinate[] CellCorners<T>(GridMapField gridMapField, double scale)
        {
            return new[]
            {
                new Coordinate(gridMapField.Coordinates.X * scale, gridMapField.Coordinates.Y * scale),
                new Coordinate((gridMapField.Coordinates.X + 1) * scale, gridMapField.Coordinates.Y * scale),
                new Coordinate((gridMapField.Coordinates.X + 1) * scale, (gridMapField.Coordinates.Y + 1) * scale),
                new Coordinate(gridMapField.Coordinates.X * scale, (gridMapField.Coordinates.Y + 1) * scale),
                new Coordinate(gridMapField.Coordinates.X * scale, gridMapField.Coordinates.Y * scale),
            };
        }
    }
}
