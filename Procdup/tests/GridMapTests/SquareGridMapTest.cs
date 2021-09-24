using Xunit;

using GridMap;
using GridMath.Shapes;

namespace GridMapTests
{
    public class SquareGridMapTest
    {
        [Fact]
        public void TestAddAreas()
        {
            var map = new SquareGridMap(10, 10);
            Assert.False(map.AddFeature(null));
            Assert.False(map.AddFeature(new Feature(new GridRectangle(-1, 0, 5, 5))));
            Assert.True(map.AddFeature(new Feature(new GridRectangle(0, 0, 5, 5))));
            Assert.False(map.AddFeature(new Feature(new GridRectangle(0, 0, 5, 5))));
            Assert.True(map.AddFeature(new Feature(new GridRectangle(5, 2, 2, 2))));
        }
    }
}