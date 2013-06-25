using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3___Play_with_Krisko
{
    class Program
    {
        static void Main()
        {
            int testsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= testsCount; i++)
            {
                string line = Console.ReadLine();
                string[] nandX = line.Split(' ');
                int n = int.Parse(nandX[0]);
                int target = int.Parse(nandX[1]);
                string[] graph = new string[n];
                for (int j = 0; j < n; j++)
                {
                    graph[j] = Console.ReadLine();
                }
                CandyGame game = new CandyGame();
                int answer = game.GetMaximumCandyCount(graph, n, target);
                Console.WriteLine(answer);
            }
        }
    }

    public class CandyGame
    {
        public const int MaxValue = 2000000000;
        public int GetMaximumCandyCount(string[] graph, int nodesCount, int target)
        {
            bool[,] adjacencyMatrix = new bool[nodesCount, nodesCount];
            int[,] shortestPaths = new int[nodesCount, nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                for (int j = 0; j < nodesCount; j++)
                {
                    shortestPaths[i, j] = 999999;
                    adjacencyMatrix[i, j] = graph[i][j] == '1';
                    if (adjacencyMatrix[i, j]) shortestPaths[i, j] = 1;
                }
                shortestPaths[i, i] = 0;
            }

            // Floyd–Warshall algorithm
            // http://en.wikipedia.org/wiki/Floyd%E2%80%93Warshall_algorithm
            for (int i = 0; i < nodesCount; i++)
            {
                for (int j = 0; j < nodesCount; j++)
                {
                    for (int k = 0; k < nodesCount; k++)
                    {
                        adjacencyMatrix[j, k] |= adjacencyMatrix[j, i] && adjacencyMatrix[i, k];
                        shortestPaths[j, k] = Math.Min(shortestPaths[j, i] + shortestPaths[i, k], shortestPaths[j, k]);
                    }
                }
            }

            // Check if we have more than 1 connected component
            for (int i = 0; i < nodesCount; i++)
            {
                for (int j = 0; j < nodesCount; j++)
                {
                    if (i != j)
                    {
                        if (!adjacencyMatrix[i, j])
                        {
                            // We have a forest of trees, not just a single tree
                            return -1;
                        }
                    }
                }
            }

            long answer = 0;
            for (int i = 0; i < nodesCount; i++)
            {
                if (shortestPaths[i, target] > 0)
                {
                    int longestLeaf = 0;
                    for (int j = 0; j < nodesCount; j++)
                    {
                        if (shortestPaths[j, target] == shortestPaths[j, i] + shortestPaths[i, target])
                        {
                            longestLeaf = Math.Max(longestLeaf, shortestPaths[j, i]);
                        }
                    }
                    answer += (long)Math.Pow(2, longestLeaf);
                }
            }

            if (answer <= MaxValue)
            {
                return (int)answer;
            }
            else
            {
                return -1;
            }
        }
    }
}
