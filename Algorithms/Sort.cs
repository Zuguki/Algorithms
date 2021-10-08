using System;

namespace Algorithms
{
    public class Sort
    {
        public static void Bubble(int[] array)
        {
            for (var wall = array.Length - 1; wall > 0; wall--)
            {
                for (var i = 0; i < wall; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }
            }
        }

        public static void Selected(int[] array)
        {
            for (var wall = array.Length - 1; wall > 0; wall--)
            {
                var maxValueIndex = 0;
                for (var i = 0; i <= wall; i++)
                {
                    maxValueIndex = array[i] > array[maxValueIndex] ? i : maxValueIndex;
                }
                Swap(array, maxValueIndex, wall);
            }
        }

        public static void Insertion(int[] array)
        {
            for (var partIndex = 1; partIndex < array.Length; partIndex++)
            {
                var curUnsorted = array[partIndex];
                var i = 1;
                for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
                    array[i] = array[i - 1];

                array[i] = curUnsorted;
            }
        }

        public static void Shell(int[] array)
        {
            var gap = 1;
            while (gap < array.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (var i = gap; i < array.Length; i++)
                {
                    for (var j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                        Swap(array, j, j - gap);
                }

                gap /= 3;
            }
        }

        public static void MergeSort(int[] array)
        {
            var aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (low >= high)
                    return;

                var mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid + 1, high);
                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                if (array[mid] <= array[mid + 1])
                    return;

                var i = low;
                var j = mid + 1;
                
                Array.Copy(array, low, aux, low, high - low + 1);
                for (var k = low; k <= high; k++)
                {
                    if (i > mid)
                        array[k] = aux[j++];
                    else if (j > high)
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i])
                        array[k] = aux[j++];
                    else
                        array[k] = aux[i++];
                }
            }
        }

        public static void Quick(int[] array)
        {
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (low >= high)
                    return;

                var j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                var i = low;
                var j = high + 1;
                var pivot = array[low];

                while (true)
                {
                    while (pivot > array[++i])
                    {
                        if (i == high)
                            break;
                    }

                    while (pivot < array[--j])
                    {
                        if (j == low)
                            break;
                    }

                    if (i >= j)
                        break;
                    
                    Swap(array, i, j);
                }

                Swap(array, low, j);
                return j;
            }
        }
        
        private static void Swap(int[] array, int from, int to)
        {
            if (from == to)
                return;
            (array[to], array[@from]) = (array[@from], array[to]);
        }
    }
}

/*
 * Bubble Sort:
 * 1000 {002ms}
 * 5000 {063ms, 065ms}
 * 10000 {278ms, 279ms}
 * 20000 {1.15ms}
 * 50000 {7.76ms}
 * 100000 {30.9938ms}
 */
    
/*
 * Selected Sort
 * 1000 {0016ms, 0015ms}
 * 5000 {035ms}
 * 10000 {142ms}
 * 20000 {562ms}
 * 50000 {3.50ms}
 * 100000 {13.96ms}
 */
    
/* Insertion Sort
 * 1000 {000649ms}
 * 5000 {0130ms}
 * 10000 {0518ms}
 * 20000 {207ms}
 * 50000 {1.283ms}
 * 100000 {5.121ms}
 */
    
/*
 * Shell Sort
 * 50000 {010ms}
 * 100000 {022ms}
 * 1000000 {29ms}
 * 10000000 {3.48ms}
 * 50000000 {19.022ms}
 */
    
/*
 * Merge Sort
 * 50000 {010ms}
 * 100000 {020ms}
 * 1000000 {22ms}
 * 10000000 {2.41ms}
 * 50000000 {12.47ms}
 */
 
/*
 * Quick Sort
 * 50000 {005ms}
 * 100000 {010ms}
 * 1000000 {105ms}
 * 10000000 {1.15ms}
 * 50000000 {6.082ms}
*/