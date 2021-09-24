using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.ProcGen.Randoms;

namespace PonderingProgrammer.Map2d.ProcGen.Rooms
{
    public static class RandomRoomsGenerator
    {
        public static List<GridRectangle> BFRandRectGenerator(IGridMap map, BFRandRectSettings settings)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rects = new List<GridRectangle>();
            var factory = new RandomBoxFactory();
            var i = 0;
            
            while (rects.Count < settings.MaxRectCount && i < settings.MaxTries)
            {
                var box = factory.RandomSizeBoxWithinBounds(
                    settings.RectWidthMin, settings.RectWidthMax, settings.RectHeightMin, settings.RectHeightMax,
                    map.Bounds);
                var rect = new GridRectangle(box);
                if (rects.All(r => !r.BoundingBox.Overlaps(box) && !r.BoundingBox.Touches(box)))
                {
                    rects.Add(rect);
                }
                i++;
            }

            return rects;
        }
    }
}
