using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FindOddNumOfOccurences
{
    class Program
    {
        static void Main(string[] args)
        {   var inputStrings = new string[] { "C#", "SQL", "PHP", "PHP", "sQL", "SQL" };
            
            //var dictionary = new Dictionary<string, int>();
           
            //foreach (var item in inputStrings)
            //{
            //    int count = 1;
            //    if (dictionary.ContainsKey(item))
            //    {
            //        count = dictionary[item] + 1;
            //    }

            //    dictionary[item] = count;
            //}
            
            var onlyoddcountlist = inputStrings.GroupBy(x => x.ToLower()).OrderBy(x => x.Count()).Where(x => x.Count() % 2 == 1);
        }
    }
}
