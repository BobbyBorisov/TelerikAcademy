using System;
using System.Linq;

namespace _03.CountWordOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            var splitters = new char[] { ' ', ',', '?', '!', '–', '.'};

            var input = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var dic = input
                .Split(splitters,StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x.ToLower())
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}

