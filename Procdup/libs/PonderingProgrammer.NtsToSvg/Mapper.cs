using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NetTopologySuite.Geometries;
using NetTopologySuite.Triangulate;
using Svg;

namespace PonderingProgrammer.NtsToSvg
{
    public static class Mapper
    {
        public static SvgPoint Map(Coordinate coordinate)
        {
            return new SvgPoint(new SvgUnit((float) coordinate.X), new SvgUnit((float) coordinate.Y));
        }

        public static SvgUnit[] MapToUnitPair(Coordinate coordinate)
        {
            return new[] {new SvgUnit((float)coordinate.X), new SvgUnit((float)coordinate.Y)};
        }

        public static IEnumerable<SvgUnit> Map(Coordinate[] coordinates)
        {
            return coordinates.SelectMany(coord => MapToUnitPair(coord));
        }
        
        public static SvgPolygon Map(Polygon polygon)
        {
            var svgPoly =  new SvgPolygon();
            svgPoly.Points = new SvgPointCollection();
            svgPoly.Points.AddRange(Map(polygon.Coordinates));
            svgPoly.Fill = new SvgColourServer(Color.Aqua);
            svgPoly.Stroke = new SvgColourServer(Color.Black); 
            return svgPoly;
        }

        public static SvgPolyline Map(LineString lineString)
        {
            var svgPolyline = new SvgPolyline();
            svgPolyline.Points = new SvgPointCollection();
            svgPolyline.Points.AddRange(Map(lineString.Coordinates));
            svgPolyline.Fill = SvgPaintServer.None;
            svgPolyline.Stroke = new SvgColourServer(Color.Black);
            return svgPolyline;
        }
    }
}
