using System;

namespace Adjacentmatrix
{
    public class AdjMatrix
    {
        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            int[,] graph = new int[nodes, nodes];

            for (int i = 0; i < nodes; i++)
            {
                string[] connections = Console.ReadLine().Split(' ');

                for (int j = 0; j < connections.Length; j++)
                {
                    graph[i, int.Parse(connections[j])] = 1;
                }
            }

            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    Console.Write(graph[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
