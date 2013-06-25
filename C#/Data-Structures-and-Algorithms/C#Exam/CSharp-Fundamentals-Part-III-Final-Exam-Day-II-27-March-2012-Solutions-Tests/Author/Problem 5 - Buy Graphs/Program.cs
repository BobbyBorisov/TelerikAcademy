using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_5___Buy_Graphs
{
    class Program
    {
        static void Main()
        {
            BestCountFinder finder = new BestCountFinder();

            int testsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testsCount; i++)
            {
                int goldCoinsCount = int.Parse(Console.ReadLine());
                Console.WriteLine(finder.FindBestCount(goldCoinsCount));
            }
        }
    }

    public class BestCountFinder
    {
        public int FindBestCount(int goldCoinsCount)
        {
            // Generating all possible prices
            HashSet<int> graphPrices = new HashSet<int>();
            graphPrices.Add(8);
            graphPrices.Add(9);
            for (int x = 0; x <= 36; x++)
            {
                for (int y = 0; y <= 3 * x - 6; y++)
                {
                    int graphPrice = x * x * x + y * y;
                    graphPrices.Add(graphPrice);
                }
            }

            int[] minimalGraphsCount = new int[goldCoinsCount + 1];
            for (int i = 0; i <= goldCoinsCount; i++)
            {
                // We can buy graphs with price 1
                minimalGraphsCount[i] = i;
            }

            // We are minimizing the number of graphs using dynamic programming
            foreach (int q in graphPrices)
            {
                for (int j = 0; j + q <= goldCoinsCount; j++)
                {
                    minimalGraphsCount[j + q] = Math.Min(minimalGraphsCount[j + q], minimalGraphsCount[j] + 1);
                }
            }
            return minimalGraphsCount[goldCoinsCount];
        }
    }
}
