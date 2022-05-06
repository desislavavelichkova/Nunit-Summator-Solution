using System;

namespace Summator
{
    public class Summator
    {
        public static int Sum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static double Average(long[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum/arr.Length;
        }
        static void Main()
        {
            Console.WriteLine(Sum(new int[] { 10, 20, 30}));
        }
    }
}
