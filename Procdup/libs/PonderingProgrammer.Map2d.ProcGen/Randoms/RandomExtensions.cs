using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Map2d.ProcGen.Randoms
{
    public static class RandomExtensions
    {
        public static float RandRange(this Random rand, float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException("max must be greater than min");
            }
            return (float)(min + rand.NextDouble() * (max - min));
        }

        public static double RandRange(this Random rand, double min, double max)
        {
            if (min >= max)
            {
                throw new ArgumentException("max must be greater than min");
            }
            return min + rand.NextDouble() * (max - min);
        }

        public static bool Chance(this Random rand, double chance)
        {
            return rand.NextDouble() < chance;
        }

        public static void Shuffle<T>(this Random rand, IList<T> list)
        {
            for (var i = list.Count; i > 0; i--)
            {
                list.Swap(0, rand.Next(0, i));
            }
        }
        
        public static T RandEnum<T>(this Random rand)
        {
            var v = Enum.GetValues(typeof (T));
            return (T) v.GetValue (rand.Next(v.Length));
        }

        public static List<T> ShuffleEnum<T>(this Random rand)
        {
            var v = Enum.GetValues(typeof (T)).OfType<T>().ToList();
            rand.Shuffle(v);
            return v;
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
