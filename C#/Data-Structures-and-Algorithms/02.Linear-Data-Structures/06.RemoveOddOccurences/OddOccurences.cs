using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveOddOccurences
{
    class OddOccurences
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 1, 2, 2, 3, 6, 2, 6 };

            //var distinct = list.Distinct();

            var groupedlist = list.GroupBy(x => x).Where(x => x.Count() % 2 == 0);
        }
    }
}
