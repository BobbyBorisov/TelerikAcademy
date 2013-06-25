using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5___Connect_All_Cities
{
    class Program
    {
        static void Main(string[] args)
        {
            int testsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= testsCount; i++)
            {
                int nodesCount = int.Parse(Console.ReadLine());
                string[] graph = new string[nodesCount];
                for (int j = 0; j < nodesCount; j++)
                {
                    graph[j] = Console.ReadLine();
                }
                TransformationsCountFinder finder = new TransformationsCountFinder();
                int answer = finder.FindTransformationsCount(graph);
                Console.WriteLine(answer);
            }
        }
    }

    public class TransformationsCountFinder
    {
        public const char CONNECTED = '1';

        public int FindTransformationsCount(string[] graph)
        {
            // We are searching for a connected component with only one node
            foreach (string nodeConnections in graph)
            {
                if (nodeConnections.IndexOf(CONNECTED) < 0)
                {
                    // Connected components with only one nodes can't be connected to
                    // any other using the given transformation
                    return -1;
                }
            }

            // Find the count of all edges
            int countOfAllEdges = 0;
            foreach (string nodeEdges in graph)
            {
                foreach (char edge in nodeEdges)
                {
                    if (edge == CONNECTED)
                    {
                        countOfAllEdges++;
                    }
                }
            }
            countOfAllEdges = countOfAllEdges / 2;

            // See if don't have enough edges to build connected graph
            if (countOfAllEdges < graph.Length - 1)
            {
                return -1;
            }

            // Find the count of all connected components - this is the answer of the task
            bool[] visited = new bool[graph.Length];
            int transformationsCount = -1;
            for (int i = 0; i < graph.Length; ++i)
            {
                if (!visited[i])
                {
                    ++transformationsCount;
                    FillNodesInConnectedComponent(i, visited, graph);
                }
            }
            return transformationsCount;
        }

        // We perform DFS to fill the component nodes
        // The result will be written in the array visited
        private void FillNodesInConnectedComponent(int i, bool[] visited, string[] graph)
        {
            if (visited[i])
            {
                return;
            }

            visited[i] = true;

            for (int j = 0; j < graph.Length; j++)
            {
                if (graph[i][j] == CONNECTED)
                {
                    FillNodesInConnectedComponent(j, visited, graph);
                }
            }
        }
    }
}
