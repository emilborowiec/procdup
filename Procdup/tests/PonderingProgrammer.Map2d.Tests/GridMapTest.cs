using System.Linq;
using PonderingProgrammer.GridMath;
using Xunit;

namespace PonderingProgrammer.Map2d.Tests
{
    public class GridMapTest
    {
        private readonly GridMap _map;

        public GridMapTest()
        {
            _map = new GridMap(6, 4);
        }
        
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 2, 14)]
        [InlineData(5, 0, 5)]
        [InlineData(0, 3, 18)]
        [InlineData(-1, 0, -1)]
        [InlineData(0, -1, -1)]
        [InlineData(6, 0, -1)]
        [InlineData(0, 4, -1)]
        [InlineData(10, 10, -1)]
        public void TestGetFieldIndex(int x, int y, int expected)
        {
            Assert.Equal(expected, _map.GetFieldIndex(x, y));
        }
        
        [Fact]
        public void TestGetFieldAt()
        {
            var coords = new GridCoordinatePair(1, 1);
            var field = _map.GetFieldAt(coords);
            Assert.NotNull(field);
            Assert.Equal(coords, field.Coordinates);
            Assert.Null(_map.GetFieldAt(10, 10));
        }

        [Fact]
        public void TestFields()
        {
            var cells = _map.Fields;
            Assert.Equal(6 * 4, cells.Length);
        }
        
        [Fact]
        public void GetCellsRowMajor()
        {
            var f1 = _map.Fields[0];
            var f2 = _map.Fields[1];
            Assert.Equal(new GridCoordinatePair(0, 0), f1.Coordinates);
            Assert.Equal(new GridCoordinatePair(1, 0), f2.Coordinates);
        }

        [Fact]
        public void GetBounds()
        {
            var bounds = _map.Bounds;
            Assert.Equal(6, bounds.Width);
            Assert.Equal(4, bounds.Height);
            Assert.Equal(0, bounds.MinX);
            Assert.Equal(0, bounds.MinY);
            Assert.Equal(6, bounds.MaxXExcl);
            Assert.Equal(4, bounds.MaxYExcl);
        }

        [Fact]
        public void FindAdjacentCells()
        {
            var map = new GridMap(9, 9);

            Assert.Equal(4, map.FindAdjacentFields(1, 1).Count());
            Assert.Equal(2, map.FindAdjacentFields(0, 0).Count());
            Assert.Equal(3, map.FindAdjacentFields(1, 0).Count());
        }

        [Fact]
        public void ToGraphNoDiagonalAdjacency()
        {
            var map = new GridMap(2, 2);
            var graph = map.GetGraph(false);

            Assert.Equal(4, graph.Nodes.Length);
            Assert.Equal(2, graph.GetAdjacentNodes(map.Fields[0]).Count());
        }

        [Fact]
        public void ToGraphWithDiagonalAdjacency()
        {
            var map = new GridMap(2, 2);
            var graph = map.GetGraph(true);

            Assert.Equal(4, graph.Nodes.Length);
            Assert.Equal(3, graph.GetAdjacentNodes(map.Fields[0]).Count());
        }
    }
}
