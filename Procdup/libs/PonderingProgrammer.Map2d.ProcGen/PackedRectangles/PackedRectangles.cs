using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.FeatureObjects;
using PonderingProgrammer.Map2d.ProcGen.Randoms;

namespace PonderingProgrammer.Map2d.ProcGen.PackedRectangles
{
    public class PackedRectangles
    {
        private RandomBoxFactory _randomBoxFactory = new RandomBoxFactory();

        public IGridMap Generate(PackedRectanglesGenerationOptions options)
        {
            var map = new GridMap(options.Width, options.Height);
            
            var rectangles = new GridBoundingBox[options.RectCount];
            for (var i = 0; i < options.RectCount; i++)
            {
                rectangles[i] = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            }
            GridBoundingBoxes.Pack(rectangles, BoxAlignment.TopLeft, options.CorridorLength);
            rectangles = rectangles.Where(r => map.Bounds.Contains(r)).ToArray();
            foreach (var rectangle in rectangles)
            {
                map.AddFeature(new GridRectFeature(FeatureType.Room, rectangle));
            }

            return map;
        }
    }
}
