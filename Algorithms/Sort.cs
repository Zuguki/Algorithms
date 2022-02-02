using System.Collections.Generic;

namespace Algorithms
{
    public static class Sort
    {
        public static int[] Bubble(int[] array)
        {
            for (var wall = array.Length; wall > 0; wall--)
            {
                for (var i = 0; i < wall - 1; i++)
                {
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }
            }

            return array;
        }

        private static void Swap(IList<int> array, int index1, int index2)
        {
            (array[index1], array[index2]) = (array[index2], array[index1]);
        }
    }
}