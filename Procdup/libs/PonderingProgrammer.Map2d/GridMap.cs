using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridMap : IGridMap
    {
        private readonly GridBoundingBox _bounds;

        public GridMap(int width, int height)
        {
            _bounds = GridBoundingBox.FromSize(0, 0, width, height);

            Fields = new GridMapField[width * height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    Fields[GetFieldIndex(x, y)] = new GridMapField(new GridCoordinatePair(x, y));
                }
            }
        }

        public GridBoundingBox Bounds => _bounds;

        public GridMapField[] Fields { get; }

        public int GetFieldIndex(int x, int y)
        {
            return HasField(x, y) ? (y * _bounds.Width) + x : -1;
        }

        public int GetFieldIndex(GridMapField field)
        {
            for (var i = 0; i < Fields.Length; i++)
            {
                if (Fields[i] == field) return i;
            }

            return -1;
        }

        public Dictionary<int, List<IGridFeatureObject>> FeatureLayers { get; } = new Dictionary<int, List<IGridFeatureObject>>();

        public void AddFeature(IGridFeatureObject feature, int layer = 0)
        {
            if (!FeatureLayers.ContainsKey(layer)) FeatureLayers[layer] = new List<IGridFeatureObject>();
            FeatureLayers[layer].Add(feature);
        }

        public GridMapField GetFieldAt(int x, int y) => HasField(x, y) ? Fields[GetFieldIndex(x, y)] : null;

        public GridMapField GetFieldAt(GridCoordinatePair coordinates) => GetFieldAt(coordinates.X, coordinates.Y);
        public ICollection<GridMapField> GetFieldsInBoundary(GridBoundingBox boundary)
        {
            return Fields.Where(f => boundary.Contains(f.Coordinates)).ToList();
        }

        public ICollection<IGridFeatureObject> GetFeaturesInBoundary(GridBoundingBox boundary)
        {
            return FeatureLayers.Values.SelectMany(list => list).Where(feature => feature.Shape.Overlaps(boundary)).ToList();
        }

        public List<IGridFeatureObject> FindFeatures(FeatureType featureType)
        {
            return FeatureLayers.Values
                .SelectMany(list => list.FindAll(f => f.FeatureType == featureType)).ToList();
        }

        public IEnumerable<GridMapField> FindFields(Func<GridMapField, bool> predicate) => Fields.Where(predicate);

        public IEnumerable<GridMapField> FindAdjacentFields(int x, int y, bool includeDiagonallyAdjacent = false)
        {
            if (GetFieldAt(x, y - 1) is { } top) yield return top;
            if (includeDiagonallyAdjacent && GetFieldAt(x + 1, y - 1) is { } topRight) yield return topRight;
            if (GetFieldAt(x + 1, y) is { } right) yield return right;
            if (includeDiagonallyAdjacent && GetFieldAt(x + 1, y + 1) is { } bottomRight) yield return bottomRight;
            if (GetFieldAt(x, y + 1) is { } bottom) yield return bottom;
            if (includeDiagonallyAdjacent && GetFieldAt(x - 1, y + 1) is { } bottomLeft) yield return bottomLeft;
            if (GetFieldAt(x - 1, y) is { } left) yield return left;
            if (includeDiagonallyAdjacent && GetFieldAt(x - 1, y - 1) is { } topLeft) yield return topLeft;

        }

        public IEnumerable<GridMapField> FindAdjacentFields(GridCoordinatePair coordinates, bool includeDiagonallyAdjacent = false)
        {
            return FindAdjacentFields(coordinates.X, coordinates.Y, includeDiagonallyAdjacent);
        }

        public GridMapAdjacencyList GetGraph(bool allowDiagonalAdjacency)
        {
            var graph = new GridMapAdjacencyList(this);
            foreach (var field in Fields)
            {
                foreach (var adjacent in FindAdjacentFields(field.Coordinates, allowDiagonalAdjacency))
                {
                    graph.AddEdge(field, adjacent, 1);
                }
            }

            return graph;
        }
        
        public GridMapAdjacencyList GetFeatureGraph(bool allowDiagonalAdjacency, FeatureType featureType)
        {
            var graph = new GridMapAdjacencyList(this, 
                field => field.FeatureLayers.Values
                    .SelectMany(l => l)
                    .Any(feature => feature.FeatureType == featureType));
            
            foreach (var field in Fields)
            {
                foreach (var adjacent in FindAdjacentFields(field.Coordinates, allowDiagonalAdjacency))
                {
                    graph.AddEdge(field, adjacent, 1);
                }
            }

            return graph;
        }
        
        private bool HasField(int x, int y)
        {
            return x >= 0 && x < _bounds.Width && y >= 0 && y < _bounds.Height;
        }
    }
}
