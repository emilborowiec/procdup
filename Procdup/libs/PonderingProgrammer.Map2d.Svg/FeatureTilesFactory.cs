﻿using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public class FeatureTilesFactory
    {
        private MapGeometryFactory _factory = new MapGeometryFactory();
        
        public List<IGridFeatureObject> Map2dToFeatureObjects(IGridMap map, double scale)
        {
            var list = new List<IGridFeatureObject>();
            foreach (var cell in map.GetCells())
            {
                var fo = new GridPointFeature(_factory.MapCellToPolygon(cell, scale),
                    cell.Value ? FeatureType.OpenSpace : FeatureType.SolidWall);
                list.Add(fo);
            }
            return list;
        }
    }
}
