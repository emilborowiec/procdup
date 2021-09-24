namespace PonderingProgrammer.Map2d
{
    public static class Aspect
    {
        public static AspectType RatioToType(double aspect)
        {
            if (aspect < 0.5) return AspectType.LONG_VERTICAL;
            if (aspect < 0.8) return AspectType.PORTAIT;
            if (aspect < 1.25) return AspectType.SQUARE;
            if (aspect < 2.0) return AspectType.LANDSCAPE;
            return AspectType.LONG_HORIZONTAL;
        }
    }
}
