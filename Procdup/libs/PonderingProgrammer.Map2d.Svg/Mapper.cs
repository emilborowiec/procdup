using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;
using Svg;

namespace PonderingProgrammer.Map2d.Svg
{
    public static class Mapper
    {
        public static SvgPoint Map(GridCoordinatePair coordinate)
        {
            return new SvgPoint(new SvgUnit(coordinate.X), new SvgUnit(coordinate.Y));
        }

        private static SvgUnit[] MapToUnitPair(GridCoordinatePair coordinate)
        {
            return new[] {new SvgUnit(coordinate.X), new SvgUnit(coordinate.Y)};
        }

        public static IEnumerable<SvgUnit> Map(GridCoordinatePair[] coordinates)
        {
            return coordinates.SelectMany(MapToUnitPair);
        }
        
        public static SvgRectangle Map(GridRectangle rect, SvgPaintServer stroke, SvgPaintServer fill)
        {
            var svgPoly = new SvgRectangle();
            svgPoly.X = rect.Rectangle.MinX;
            svgPoly.Y = rect.Rectangle.MinY;
            svgPoly.Width = rect.Rectangle.Width;
            svgPoly.Height = rect.Rectangle.Height;
            svgPoly.Stroke = stroke;
            svgPoly.Fill = fill;
            return svgPoly;
        }

        public static SvgPath Map(GridPolyPoint polyPoint)
        {
            var svgPolyline = new SvgPath();
            svgPolyline.
            svgPolyline.Points = new SvgPointCollection();
            svgPolyline.Points.AddRange(Map(polyPoint.Coordinates));
            svgPolyline.Stroke = stroke;
            svgPolyline.Fill = fill;
            return svgPolyline;
        }
        
    }
}