using System;
using System.Collections.Generic;

namespace DFSRecursiveOOPGraph
{
    public class Graph
    {
        public int[][] childNodes;
        private HashSet<int> visited;

        public Graph(int[][] nodes)
        {
            this.childNodes = nodes;
            this.visited = new HashSet<int>();
        }

        public void DFSRecursive(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                Console.WriteLine(node);

                for (int i = 0; i < childNodes[node].Length; i++)
                {
                    DFSRecursive(childNodes[node][i]);
                }
            }
        }
    }
}
