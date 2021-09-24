using NetTopologySuite.Geometries;
using PonderingProgrammer.Map2d.FeatureObjects;
using PonderingProgrammer.NtsToSvg;
using Svg;

namespace PonderingProgrammer.Map2d.Svg
{
    public class Map2dSvgRenderer
    {
        private FeatureSvgStyleMapper _styleMapper = new FeatureSvgStyleMapper();
        
        public SvgDocument RenderToSvg(IGridMap map, double scale)
        {
            var svg = new SvgDocument();
            SvgElement background = new SvgRectangle();
            svg.Children.Add(background);
            
            
            var cellFeatures = _featureTilesFactory.Map2dToFeatureObjects(map, scale);
            foreach (var cell in cellFeatures)
            {
                var cellSvg = Mapper.Map(cell.Geometry as Polygon);
                _styleMapper.StyleThis(cellSvg, cell);
                svg.Children.Add(cellSvg);
            }
            return svg;
        }
    }
}
