using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ReadNumbersAndSort
{
    class ConsoleReader
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 6, 5, 4 };

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

            list.Sort();

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
