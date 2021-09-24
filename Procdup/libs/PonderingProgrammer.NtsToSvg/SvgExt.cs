using System;
using System.Linq;
using NetTopologySuite.Geometries;
using Svg;

namespace PonderingProgrammer.NtsToSvg
{
    public static class SvgExt
    {
        public static string GetHtml(this SvgDocument svg)
        {
            return string.Join("", svg.Children.Select(child => child.GetXML()));
        }
    }
}
