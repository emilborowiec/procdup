using System.Collections.Generic;
using GridMath;
using GridMath.Shapes;
using QuickGraph;

namespace GridMap
{
    public class Feature : IFeature
    {
        private Dictionary<GridCoordinatePair, SquareMapField> _fields = new Dictionary<GridCoordinatePair, SquareMapField>();
        private Dictionary<string, string> _strAttributes = new Dictionary<string, string>();
        private Dictionary<string, bool> _flagAttributes = new Dictionary<string, bool>();
        private Dictionary<string, int> _numAttributes = new Dictionary<string, int>();
        
        public Feature(IGridShape shape)
        {
            Shape = shape;
            FieldGraph = new AdjacencyGraph<SquareMapField, Edge<SquareMapField>>();
            foreach (var coords in Shape.Interior)
            {
                var field = new SquareMapField(coords, this);
                _fields[coords] = field;
                FieldGraph.AddVertex(field);
            }

            foreach (var field in _fields.Values)
            {
                foreach (var adjacentField in FindAdjacentFields(field.Coordinates))
                {
                    FieldGraph.AddEdge(new Edge<SquareMapField>(field, adjacentField));
                }
            }
        }

        public IGridShape Shape { get; }
        public AdjacencyGraph<SquareMapField, Edge<SquareMapField>> FieldGraph { get; }
        
        public bool HasFieldAt(int x, int y)
        {
            return HasFieldAt(new GridCoordinatePair(x, y));
        }

        public bool HasFieldAt(GridCoordinatePair coordinates)
        {
            return Shape.Contains(coordinates);
        }

        public SquareMapField GetFieldAt(int x, int y)
        {
            return GetFieldAt(new GridCoordinatePair(x, y));
        }

        public SquareMapField GetFieldAt(GridCoordinatePair coordinates)
        {
            return HasFieldAt(coordinates) ? _fields[coordinates] : null;
        }

        private IEnumerable<SquareMapField> FindAdjacentFields(int x, int y, bool includeDiagonallyAdjacent = false)
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

        private IEnumerable<SquareMapField> FindAdjacentFields(GridCoordinatePair coordinates, bool includeDiagonallyAdjacent = false)
        {
            return FindAdjacentFields(coordinates.X, coordinates.Y, includeDiagonallyAdjacent);
        }

        public void SetAttribute(string name, string value)
        {
            _strAttributes[name] = value;
        }

        public void SetAttribute(string name, bool value)
        {
            _flagAttributes[name] = value;
        }

        public void SetAttribute(string name, int value)
        {
            _numAttributes[name] = value;
        }

        public string GetStrAttribute(string name)
        {
            return _strAttributes[name];
        }

        public bool GetFlagAttribute(string name)
        {
            return _flagAttributes[name];
        }

        public int GetNumAttribute(string name)
        {
            return _numAttributes[name];
        }
    }
}