#region

using System;
using PonderingProgrammer.GridMath;

#endregion

namespace PonderingProgrammer.Map2d.ProcGen.Randoms
{
    public class RandomBoxFactory
    {
        private static void ValidateSizeLimits(int minSize, int maxSize)
        {
            if (minSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(minSize), "size must be > 0");
            }

            if (maxSize < minSize)
            {
                throw new ArgumentOutOfRangeException(nameof(minSize), "maxSize must be >= minSize");
            }

        }

        private readonly Random _rand = new Random();

        public GridBoundingBox RandomSizeBox(int minSize, int maxSize)
        {
            ValidateSizeLimits(minSize, maxSize);

            return GridBoundingBox.FromSize(0, 0, _rand.Next(minSize, maxSize + 1), _rand.Next(minSize, maxSize + 1));
        }

        public GridBoundingBox RandomSizeBox(int widthMin, int widthMax, int heightMin, int heightMax)
        {
            ValidateSizeLimits(widthMin, widthMax);
            ValidateSizeLimits(heightMin, heightMax);

            return GridBoundingBox.FromSize(
                0, 0, _rand.Next(widthMin, widthMax + 1), _rand.Next(heightMin, heightMax + 1));
        }

        public GridBoundingBox RandomSizeBoxWithinBounds(int minSize, int maxSize, GridBoundingBox bounds)
        {
            ValidateSizeLimits(minSize, maxSize);

            var width = Math.Min(_rand.Next(minSize, maxSize + 1), bounds.Width);
            var height = Math.Min(_rand.Next(minSize, maxSize + 1), bounds.Height);

            var minX = _rand.Next(bounds.MinX, (bounds.MaxXExcl - width) + 1);
            var minY = _rand.Next(bounds.MinY, (bounds.MaxYExcl - height) + 1);

            return GridBoundingBox.FromSize(minX, minY, width, height);
        }

        public GridBoundingBox RandomSizeBoxWithinBounds(
            int widthMin,
            int widthMax,
            int heightMin,
            int heightMax,
            GridBoundingBox bounds)
        {
            ValidateSizeLimits(widthMin, widthMax);
            ValidateSizeLimits(heightMin, heightMax);

            var width = Math.Min(_rand.Next(widthMin, widthMax + 1), bounds.Width);
            var height = Math.Min(_rand.Next(heightMin, heightMax + 1), bounds.Height);

            var minX = _rand.Next(bounds.MinX, (bounds.MaxXExcl - width) + 1);
            var minY = _rand.Next(bounds.MinY, (bounds.MaxYExcl - height) + 1);

            return GridBoundingBox.FromSize(minX, minY, width, height);
        }
    }
}
