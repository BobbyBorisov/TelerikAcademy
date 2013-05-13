namespace RefactoredForLoop
{
    using System;
    using System.Linq;

    public class Refactored
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 7, 11, 100, 24, 50, 666};
            bool expectedValueFound = false;
            var expectedValue = 666;

            for (int i = 0; i < array.Length; i++)
            { 
                Console.WriteLine("array[{0}]={1}",i,array[i]);

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        expectedValueFound = true;
                        break;
                    }
                }
            }

            // More code here
            if (expectedValueFound)
            {
                Console.WriteLine("Value {0} has been found",expectedValue);
            }
        }
    }
}
