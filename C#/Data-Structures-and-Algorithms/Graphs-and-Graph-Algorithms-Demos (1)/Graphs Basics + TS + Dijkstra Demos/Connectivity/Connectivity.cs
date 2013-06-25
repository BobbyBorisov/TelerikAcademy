using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity
{
    class Connectivity
    {
        static bool[] visited;
        static int[,] graph;

        public static void BFS(int node)
        {
            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(node);
            visited[node] = true;
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[currentNode, i] == 1 && !visited[i])
                    {
                        nodes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        public static void Main()
        {
            int nodes = 6;

            visited = new bool[6];

            graph = new int[6, 6]
            { 
                {0,1,1,0,0,0},
                {0,0,1,0,0,0},
                {1,1,0,0,0,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,1},
                {0,0,0,0,1,0},
            };

            int components = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    BFS(i);
                    components++;
                }
            }

            Console.WriteLine("Connected components: " + components);

            if (components == 1)
            {
                Console.WriteLine("Graph is connected");
            }
            else
            {
                Console.WriteLine("Graph is not connected");
            }
        }
    }
}
