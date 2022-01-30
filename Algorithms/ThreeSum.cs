namespace Algorithms
{
    public class ThreeSum
    {
        public static int Count(int[] array)
        {
            var count = 0;

            for (var first = 0; first < array.Length - 2; first++)
            {
                for (var second = first + 1; second < array.Length - 1; second++)
                {
                    for (var third = second + 1; third < array.Length; third++)
                        count += array[first] + array[second] + array[third] == 0 ? 1 : 0;
                }   
            }

            return count;
        }
    }
}