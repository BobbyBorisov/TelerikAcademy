using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindNumberOfOccurences
{
    class NumberOfOccurences
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };


            var occurencesList = list.GroupBy(x => x);
            foreach (var item in occurencesList)
            {
                Console.WriteLine("{0}->{1} time/s", item.Key, item.Count());
            }
        }
    }
}
