using System;
using System.Diagnostics;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //const int arrayLength = 50000000;
            //var rnd = new Random();
            //var arr = new int[arrayLength];
            //
            //for (var i = 0; i < arrayLength; i++) arr[i] = rnd.Next(0, 1000);
//
            //MeasureTime(arr);

            var heap = new MaxHeap<int>();
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(65);
            heap.Insert(4);
            heap.Insert(5);

            Console.Write("> ");
            foreach (var value in heap.Values())
            {
                Console.Write($"{value} ");
            }
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