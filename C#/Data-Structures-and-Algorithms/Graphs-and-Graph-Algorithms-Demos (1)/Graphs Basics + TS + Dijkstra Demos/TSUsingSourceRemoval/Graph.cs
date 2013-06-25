using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSUsingSourceDFS
{
    class Graph
    {
        private int[,] edges;

        private int count;

        public bool[] visitedElements;

        public List<int> sortedElements = new List<int>();

        public Graph(int[,] e)
        {
            this.edges = e;
            this.count = e.GetLength(0);
            this.visitedElements = new bool[this.count];
        }

        public void Dfs(int startIndex)
        {
            visitedElements[startIndex] = true;

            for (int k = 0; k < this.count; k++)
            {
                if ((this.edges[startIndex, k] == 1) && (visitedElements[k] == false))
                {
                    Dfs(k);
                }
            }

            sortedElements.Add(startIndex);
        }


        public void TestDfs()
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.visitedElements[i] == false)
                {
                    Dfs(i);
                }
            }
        }

        public void ShowSort()
        {
            sortedElements.Reverse();

            for (int i = 0; i < sortedElements.Count; i++)
            {
                Console.Write("{0} ", sortedElements[i]);
            }
        }

    }
}
