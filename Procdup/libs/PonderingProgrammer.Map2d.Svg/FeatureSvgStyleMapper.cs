using System.Drawing;
using PonderingProgrammer.Map2d.FeatureObjects;
using Svg;

namespace PonderingProgrammer.Map2d.Svg
{
    public class FeatureSvgStyleMapper
    {
        public void StyleThis(SvgElement element, IGridFeatureObject gridFeature)
        {
            element.Stroke = new SvgColourServer(Color.Black);
            element.Fill = new SvgColourServer(gridFeature.FeatureType == FeatureType.OpenSpace ? Color.Bisque : Color.DarkSlateGray);
            element.StrokeWidth = new SvgUnit(1);
        }
    }
}
