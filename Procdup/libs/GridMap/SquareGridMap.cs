using System;
using System.Collections.Generic;
using System.Linq;
using GridMath;

namespace GridMap
{
    public class SquareGridMap : IGridMap
    {
        private List<IFeature> _features = new List<IFeature>();
        
        public SquareGridMap(int width, int height)
        {
            Bounds = GridBoundingBox.FromSize(0, 0, width, height);
        }

        public GridBoundingBox Bounds { get; }
        public IReadOnlyList<IFeature> Features => _features.AsReadOnly();
        public bool AddFeature(IFeature feature)
        {
            if (feature == null) return false;
            if (!Bounds.Contains(feature.Shape.BoundingBox)) return false;
            if (_features.Any(a => a.Shape.Overlaps(feature.Shape.BoundingBox))) return false;
            _features.Add(feature);
            return true;
        }

        public bool RemoveFeature(IFeature feature)
        {
            return _features.Remove(feature);
        }
    }
}