using Microsoft.Xna.Framework;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.ProcGenDemo
{
    public static class GridBoundingBoxExtensions
    {
        public static Rectangle ToRectangle(this GridBoundingBox box, int scale = 1)
        {
            return new Rectangle(box.MinX * scale, box.MinY * scale, box.Width * scale, box.Height * scale);
        }
    }
}
