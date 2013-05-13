namespace Statistics
{
    using System;
    using System.Linq;

    public static class StatisticsEngine
    {
        public static void PrintStatistics(double[] arr)
        {
            var max = FindMax(arr);
            var min = FindMin(arr);
            var averageValue = GetAverage(arr);
            
            Console.WriteLine("Max is {0}", max);
            Console.WriteLine("Min is {0}", min);
            Console.WriteLine("Average is {0}", averageValue);
        }

        private static double FindMax(double[] arr)
        {
            double max = double.MinValue;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        private static double FindMin(double[] arr)
        {
            double min = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        private static double GetAverage(double[] arr)
        {
            var sumOfValues = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                sumOfValues += arr[i];
            }

            var averageValue = sumOfValues / arr.Length;

            return averageValue;
        }
    }
}
