using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestSequenceEqualNumbers
{
    class LongestSequence
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 4, 6, 4, 5, 4 };

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
            var maxSequence = 0;
            var startIndex = 0;
            var sequenceCount = 0;
            for (var i = 1; i < list.Count; i++)
            {


                if (list[i - 1] != list[i])
                {
                    sequenceCount = 1;
                    continue;
                }

                sequenceCount++;

                if (sequenceCount > maxSequence)
                {
                    maxSequence = sequenceCount;
                    startIndex = i - sequenceCount + 1;
                }
            }

            var sublist = list.GetRange(startIndex, maxSequence);
            Console.WriteLine(maxSequence);
        }
    }
}
