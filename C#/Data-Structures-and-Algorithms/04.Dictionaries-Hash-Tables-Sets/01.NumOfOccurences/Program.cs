using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NumOfOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<int,int>();
            var  array = new int[] {3, 4, 4, -2, 3, 3, 4, 3, -2};
            foreach (var item in array)
            {
                int count = 1;
                if(dictionary.ContainsKey(item))
                {
                    count = dictionary[item] + 1;
                }

                dictionary[item] = count;
            }

            foreach (var pair in dictionary) 
            {
                Console.WriteLine("{0} - > {1}",pair.Key,pair.Value);
            }

            dictionary.Clear();

            var dict = new Dictionary<string, int>();
            var inputStrings= new string[]{"C#", "SQL", "PHP", "PHP", "SQL", "SQL"};
            foreach (var item in inputStrings)
            {
                int count = 1;
                if (dict.ContainsKey(item))
                {
                    count = dict[item] + 1;
                }

                dict[item] = count;
            }

            var list = new List<int>() { 3, 4, 4, -2, 3, 3, 4, 3, -2 };
            var sorted = list.GroupBy(x => x).OrderBy(x => x.Count());
            var onlyoddcountlist = inputStrings.GroupBy(x => x.ToLower()).OrderBy(x => x.Count()).Where(x => x.Count() % 2 == 1);

            var input = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var dic = input.Split(new char[] { ' ', ',', '?', '!', '–', '.' }).GroupBy(x => x.ToLower()).ToDictionary(g => g.Key, g => g.Count());

        }
    }
}
