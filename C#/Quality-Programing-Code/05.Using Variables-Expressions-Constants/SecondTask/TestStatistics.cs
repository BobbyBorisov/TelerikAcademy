namespace Statistics
{
    using System;
    using System.Linq;
    
    public static class TestStatistics
    {
        public static void Main(string[] args)
        {
            double[] arr = { 1.4, 2.5, 5.4, 2.6, 1.2 };
            StatisticsEngine.PrintStatistics(arr);
        }
    }
}
