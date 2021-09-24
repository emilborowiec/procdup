using GridMath;
using GridMath.Shapes;
using QuickGraph;

namespace GridMap
{
    public interface IFeature
    {
        IGridShape Shape { get; }
        AdjacencyGraph<SquareMapField, Edge<SquareMapField>> FieldGraph { get; }
        bool HasFieldAt(int x, int y);
        bool HasFieldAt(GridCoordinatePair coordinates);
        SquareMapField GetFieldAt(int x, int y);
        SquareMapField GetFieldAt(GridCoordinatePair coordinates);
        void SetAttribute(string name, string value);
        void SetAttribute(string name, bool value);
        void SetAttribute(string name, int value);
        string GetStrAttribute(string name);
        bool GetFlagAttribute(string name);
        int GetNumAttribute(string name);
    }
}