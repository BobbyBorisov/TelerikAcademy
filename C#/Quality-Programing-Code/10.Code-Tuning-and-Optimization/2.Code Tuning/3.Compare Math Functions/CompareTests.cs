using System;
using System.Diagnostics;

namespace CompareMathFunctions
{
    public class CompareTests
    {
        
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.Write(stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            int intValue = 1;
            long longValue = 1L;
            float floatValue = 1F;
            double doubleValue = 1;
            decimal decimalValue = 1M;

            // SquareRoot method results 
            CompareTests.DisplayExecutionTime(() => { CompareMethods.SquareRoot(intValue); });
            Console.WriteLine(" - Compare SquareRoot method with int.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.SquareRoot(longValue); });
            Console.WriteLine(" - Compare SquareRoot method with long.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.SquareRoot(floatValue); });
            Console.WriteLine(" - Compare SquareRoot method with float.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.SquareRoot(doubleValue); });
            Console.WriteLine(" - Compare SquareRoot method with double.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.SquareRoot(decimalValue); });
            Console.WriteLine(" - Compare SquareRoot method with decimal.");
            Console.WriteLine(new string('-', 60));

            // NaturalLogarithm method results 
            CompareTests.DisplayExecutionTime(() => { CompareMethods.NaturalLogarithm(intValue); });
            Console.WriteLine(" - Compare NaturalLogarithm method with int.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.NaturalLogarithm(longValue); });
            Console.WriteLine(" - Compare NaturalLogarithm method with long.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.NaturalLogarithm(floatValue); });
            Console.WriteLine(" - Compare NaturalLogarithm method with float.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.NaturalLogarithm(doubleValue); });
            Console.WriteLine(" - Compare NaturalLogarithm method with double.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.NaturalLogarithm(decimalValue); });
            Console.WriteLine(" - Compare NaturalLogarithm method with decimal.");
            Console.WriteLine(new string('-', 60));

            // Sinus method results 
            CompareTests.DisplayExecutionTime(() => { CompareMethods.Sinus(intValue); });
            Console.WriteLine(" - Compare Sinus method with int.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.Sinus(longValue); });
            Console.WriteLine(" - Compare Sinus method with long.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.Sinus(floatValue); });
            Console.WriteLine(" - Compare Sinus method with float.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.Sinus(doubleValue); });
            Console.WriteLine(" - Compare Sinus method with double.");
            CompareTests.DisplayExecutionTime(() => { CompareMethods.Sinus(decimalValue); });
            Console.WriteLine(" - Compare Sinus method with decimal.");
            Console.WriteLine(new string('-', 60));
        }
    }
}
