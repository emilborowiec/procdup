using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PonderingProgrammer.GridMath;
using RandomBoxFactory = PonderingProgrammer.Map2d.ProcGen.Randoms.RandomBoxFactory;

namespace PonderingProgrammer.Map2d.ProcGen.PoppingRectangles
{
    public class PoppingRectangles
    {
        public IGridMap Generate(PoppingRectanglesGenerationOptions options)
        {
            return new GridMap(options.Width, options.Height);
//            var context = new ValidationContext(options);
//            var validationResults = new List<ValidationResult>();
//            if (!Validator.TryValidateObject(options, context, validationResults))
//            {
//                throw new ArgumentException(string.Join(";", validationResults.Select(r => r.ErrorMessage)));
//            }
//            var rand = new Random();
//            var randBoxFactory = new RandomBoxFactory();
//            var map = new GridMap(options.Width, options.Height);
//            var superBounds = map.Bounds;
//
//            var firstRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
//            firstRect = firstRect.Relate(superBounds, Relation.CenterToCenter(),
//                Relation.CenterToCenter());
//            
//            map.AddFeature(new Gr);
//            var seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
//            while (seeds.Count > 0)
//            {
//                var seedIndex = rand.Next(0, seeds.Count);
//                var coord = seeds[seedIndex].Coordinates;
//                seeds.RemoveAt(seedIndex);
//                var newRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
//                newRect = newRect.SetPosition(coord.X, coord.Y, IntervalAnchor.Center, IntervalAnchor.Center);
//                if (!superBounds.Contains(newRect))
//                {
//                    continue;
//                }
//
//                seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
//                map.SetInBounds(true, newRect);
//            }
//
//            return map;
        }

//        private List<GridMapField> FindFreeRangeSurfaceCells(IGridMap map, int range)
//        {
//            var minX = map.Bounds.MinX + range;
//            var minY = map.Bounds.MinY + range;
//            var maxX = map.Bounds.MaxXExcl - range;
//            var maxY = map.Bounds.MaxYExcl - range;
//            return FindFreeSurfaceCells(map).Where(c =>
//                c.Coordinates.X >= minX && c.Coordinates.Y >= minY && c.Coordinates.X < maxX && c.Coordinates.Y < maxY)
//                .ToList();
//        }
//
//        private IEnumerable<GridMapField> FindFreeSurfaceCells(IGridMap map)
//        {
//            return map.FindCellsByValue(v => v)
//                .Where(c => map.FindAdjacentFields(c.Coordinates).Any(ac => ac.Value == false));
//        }
    }
}
