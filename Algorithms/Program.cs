using System;

namespace Algorithms
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Sort.Bubble(new [] {1, 5, 2, 1, 3, 8, 4, 2}))
            {
                Console.Write($"{item} ");
            }
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
