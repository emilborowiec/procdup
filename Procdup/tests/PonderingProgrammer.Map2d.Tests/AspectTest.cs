using Xunit;

namespace PonderingProgrammer.Map2d.Tests
{
    public class AspectTest
    {
        [Fact]
        public void AspectRatioToAspectTypeTest()
        {
            Assert.Equal(AspectType.SQUARE, Aspect.RatioToType(100f / 100));
            Assert.Equal(AspectType.LANDSCAPE, Aspect.RatioToType(140f / 100));
            Assert.Equal(AspectType.PORTAIT, Aspect.RatioToType(100f / 160));
            Assert.Equal(AspectType.LONG_HORIZONTAL, Aspect.RatioToType(300f / 100));
            Assert.Equal(AspectType.LONG_VERTICAL, Aspect.RatioToType(100f / 220));
        }
    }
}
