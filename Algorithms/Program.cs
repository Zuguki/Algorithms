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

            var mySearch = new SequentialSearchSt<int, int>();
            mySearch.Add(1, 1);
            mySearch.Add(2, 2);
            mySearch.Add(3, 3);
            mySearch.Add(4, 4);
            mySearch.Add(5, 5);
            mySearch.Add(6, 1);
            mySearch.Add(6, 6);

            Console.WriteLine(mySearch.TryGet(6, out var value));
            Console.WriteLine(value);

            Console.WriteLine(mySearch.Count);
            
            Console.WriteLine(mySearch.Contains(3));
            Console.WriteLine(mySearch.Contains(8));

            Console.Write("> ");
            foreach (var key in mySearch.Keys())
            {
                Console.Write($"{key} ");
            }
            Console.WriteLine();

            mySearch.Remove(6);
            mySearch.Remove(1);
            mySearch.Remove(3);
            
            Console.Write("> ");
            foreach (var key in mySearch.Keys())
            {
                Console.Write($"{key} ");
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