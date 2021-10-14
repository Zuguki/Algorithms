using System;
using System.Diagnostics;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int arrayLength = 50000000;
            var rnd = new Random();
            var arr = new int[arrayLength];
            
            for (var i = 0; i < arrayLength; i++) arr[i] = rnd.Next(0, 1000);

            MeasureTime(arr);
        }

        private static void MeasureTime(int[] arr)
        {
            var sw = new Stopwatch();
            
            sw.Start();
            Sort.Quick(arr);
            sw.Stop();
            
            Console.WriteLine(sw.Elapsed);
        }

        private static void Output(int[] arr)
        {
            Sort.Quick(arr);
            
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}