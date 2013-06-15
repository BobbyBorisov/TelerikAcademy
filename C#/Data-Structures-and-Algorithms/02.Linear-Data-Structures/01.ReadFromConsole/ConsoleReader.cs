using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReadFromConsole
{
    class ConsoleReader
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 4, 6 };
            //Uncomment and remove the initial numbers in the list to use the console.
            //while (true) 
            //{
            //    string input = Console.ReadLine();
            //    if (input == string.Empty) 
            //    {
            //        break;
            //    }

            //    list.Add(int.Parse(input));
            //}

            var average = list.Average();
            Console.WriteLine(average);

            var sum = list.Sum();
            Console.WriteLine(sum);
        }
    }
}
