using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem_1___Maximal_Path
{
    class MaximalPath
    {
        static void Main()
        {
            Tree tree = new Tree();
            tree.ReadFromStream(Console.In);
            Console.WriteLine(tree.GetMaximalPathLenght());
        }
    }

    class Tree
    {
        private readonly Dictionary<int, List<int>> adjacent;
        private readonly HashSet<int> leaves;
        private readonly HashSet<int> parents;

        public Tree()
        {
            adjacent = new Dictionary<int, List<int>>();
            leaves = new HashSet<int>();
            parents = new HashSet<int>();
        }

        public void AddDirectedEdge(int from, int to)
        {
            if (!adjacent.ContainsKey(from))
            {
                adjacent.Add(from, new List<int>());
            }
            adjacent[from].Add(to);
        }

        public void AddEdge(int vertexA, int vertexB)
        {
            AddDirectedEdge(vertexA, vertexB);
            AddDirectedEdge(vertexB, vertexA);
        }

        public void ReadFromStream(TextReader input)
        {
            int n = int.Parse(input.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                string[] vertices = input.ReadLine().Split(
                    new char[] { ' ', '(', ')', '-', '>', '<' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(vertices[0]);
                int child = int.Parse(vertices[1]);
                AddEdge(parent, child);
                leaves.Add(child);
                parents.Add(parent);
                leaves.Remove(parent);
            }
        }

        private HashSet<int> usedNodes;
        private long maxPathValue;

        private void DFSGetMaxPathValue(int node, long currentPathValue)
        {
            usedNodes.Add(node);
            currentPathValue += node;
            if (leaves.Contains(node))
            {
                maxPathValue = Math.Max(maxPathValue, currentPathValue);
            }
            foreach (int neighbor in adjacent[node])
            {
                if (usedNodes.Contains(neighbor))
                {
                    continue;
                }
                DFSGetMaxPathValue(neighbor, currentPathValue);
            }
        }

        private void GetMaximalPathValue()
        {
            usedNodes = new HashSet<int>();
            maxPathValue = long.MinValue;
            foreach (int node in leaves)
            {
                usedNodes.Clear();
                DFSGetMaxPathValue(node, 0);
            }
        }

        public long GetMaximalPathLenght()
        {
            GetMaximalPathValue();
            usedNodes = new HashSet<int>();
            return maxPathValue;
        }
    }
}
