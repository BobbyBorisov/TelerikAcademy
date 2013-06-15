using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindMajorantNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };


            var groupedlist = list.GroupBy(x => x).Where(x => x.Count() >= (list.Count / 2 + 1));

            if (groupedlist.Count() < 0)
            {
                Console.WriteLine("The majorant does not exist!");
            }
        }
    }
}
