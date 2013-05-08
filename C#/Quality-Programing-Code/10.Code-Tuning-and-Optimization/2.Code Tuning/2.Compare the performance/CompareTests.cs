using System;

namespace CompareThePerformance
{
    class CompareTests
    {
        static void Main()
        {
            int intValue = 1;
            long longValue = 1L;
            float floatValue = 1F;
            double doubleValue = 1;
            decimal decimalValue = 1M;

            // Add method results 
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Add(intValue); });
            Console.WriteLine(" - Compare add method with int.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Add(longValue); });
            Console.WriteLine(" - Compare add method with long.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Add(floatValue); });
            Console.WriteLine(" - Compare add method with float.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Add(doubleValue); });
            Console.WriteLine(" - Compare add method with double.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Add(decimalValue); });
            Console.WriteLine(" - Compare add method with decimal.");
            Console.WriteLine(new string('-', 60));

            // Substract method results 
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Substract(intValue); });
            Console.WriteLine(" - Compare substract method with int.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Substract(longValue); });
            Console.WriteLine(" - Compare substract method with long.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Substract(floatValue); });
            Console.WriteLine(" - Compare substract method with float.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Substract(doubleValue); });
            Console.WriteLine(" - Compare substract method with double.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Substract(decimalValue); });
            Console.WriteLine(" - Compare substract method with decimal.");
            Console.WriteLine(new string('-', 60));

            // Increment method results 
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Increment(intValue); });
            Console.WriteLine(" - Compare increment method with int.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Increment(longValue); });
            Console.WriteLine(" - Compare increment method with long.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Increment(floatValue); });
            Console.WriteLine(" - Compare increment method with float.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Increment(doubleValue); });
            Console.WriteLine(" - Compare increment method with double.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Increment(decimalValue); });
            Console.WriteLine(" - Compare increment method with decimal.");
            Console.WriteLine(new string('-', 60));

            // Multiply method results 
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Multiply(intValue); });
            Console.WriteLine(" - Compare multiply method with int.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Multiply(longValue); });
            Console.WriteLine(" - Compare multiply method with long.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Multiply(floatValue); });
            Console.WriteLine(" - Compare multiply method with float.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Multiply(doubleValue); });
            Console.WriteLine(" - Compare multiply method with double.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Multiply(decimalValue); });
            Console.WriteLine(" - Compare multiply method with decimal.");
            Console.WriteLine(new string('-', 60));

            // Divide method results 
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Divide(intValue); });
            Console.WriteLine(" - Compare divide method with int.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Divide(longValue); });
            Console.WriteLine(" - Compare divide method with long.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Divide(floatValue); });
            Console.WriteLine(" - Compare divide method with float.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Divide(doubleValue); });
            Console.WriteLine(" - Compare divide method with double.");
            CompareMethods.DisplayExecutionTime(() => { CompareMethods.Divide(decimalValue); });
            Console.WriteLine(" - Compare divide method with decimal.");
            Console.WriteLine(new string('-', 60));
        }
    }
}
