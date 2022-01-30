using System;

namespace Algorithms
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ThreeSum.Count(GetRandomInts(100)));
        }

        private static int[] GetRandomInts(int count)
        {
            var ints = new int[count];
            var rnd = new Random();

            for (var i = 0; i < count; i++)
                ints[i] = rnd.Next(-1, 1);

            return ints;
        }
    }
}
