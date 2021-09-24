using System.Collections.Generic;
using System.Linq;
using GridMap;
using GridMath.Shapes;
using Xunit;

namespace GridMapTests
{
    public class MapAreaTest
    {
        [Fact]
        public void TestHasField()
        {
            var area = new Feature(new GridRectangle(0, 0, 10, 10));
            Assert.False(area.HasFieldAt(-1, 0));
            Assert.True(area.HasFieldAt(0, 0));
            Assert.True(area.HasFieldAt(9, 9));
            Assert.False(area.HasFieldAt(10, 10));
        }

        [Fact]
        public void TestGetField()
        {
            var area = new Feature(new GridRectangle(0, 0, 10, 10));
            Assert.Equal(5, area.GetFieldAt(5, 0).Coordinates.X);
        }

        [Fact]
        public void TestGraphEdges()
        {
            var area = new Feature(new GridRectangle(0, 0, 2, 2));
            area.FieldGraph.TryGetOutEdges(area.GetFieldAt(0, 0), out var edges);
            Assert.Equal(2, edges.Count());
        }
    }
}