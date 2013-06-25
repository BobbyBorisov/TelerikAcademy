using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_2___Risk_Wins__Risk_Loses
{
    class LowestButtonsCountSlowFinder
    {
        const int MaxNumber = 99999;
        const int WheelsCount = 5;
        private readonly int startEdge;
        private readonly int endEdge;
        private readonly bool[] isForbiddenEdge;

        public LowestButtonsCountSlowFinder(string startCombination, string finalCombination, List<string> forbiddenCombinations)
        {
            this.startEdge = int.Parse(startCombination);
            this.endEdge = int.Parse(finalCombination);
            this.isForbiddenEdge = new bool[MaxNumber + 1]; // All false by default
            foreach (string forbiddenCombination in forbiddenCombinations)
            {
                this.isForbiddenEdge[int.Parse(forbiddenCombination)] = true;
            }
        }

        public int Find()
        {
            int result = BFS(this.startEdge, this.endEdge);
            return result;
        }

        private int BFS(int startEdge, int endEdge)
        {
            bool[] used = new bool[MaxNumber + 1];
            int level = 0;
            Queue<int> nodesQueue = new Queue<int>();
            nodesQueue.Enqueue(startEdge);
            while (nodesQueue.Count > 0)
            {
                Queue<int> nextLevelNodes = new Queue<int>();
                level++;
                while (nodesQueue.Count > 0)
                {
                    int node = nodesQueue.Dequeue();
                    string nodeAsString = node.ToString("00000");
                    if (node == endEdge)
                    {
                        return level - 1;
                    }

                    // Pressing the left button
                    for (int i = 0; i < WheelsCount; i++)
                    {
                        StringBuilder nodeAsStringBuilder = new StringBuilder(nodeAsString);
                        nodeAsStringBuilder[i] += (char)1;
                        if (nodeAsStringBuilder[i] > '9') nodeAsStringBuilder[i] -= (char)10;
                        int newNode = int.Parse(nodeAsStringBuilder.ToString());
                        if (used[newNode]) continue;
                        if (isForbiddenEdge[newNode]) continue;
                        // the new node is not visited and is not forbidden, so add it in the queue
                        used[newNode] = true;
                        nextLevelNodes.Enqueue(newNode);
                    }

                    // Pressing the right button
                    for (int i = 0; i < WheelsCount; i++)
                    {
                        StringBuilder nodeAsStringBuilder = new StringBuilder(nodeAsString);
                        nodeAsStringBuilder[i] -= (char)1;
                        if (nodeAsStringBuilder[i] < '0') nodeAsStringBuilder[i] += (char)10;
                        int newNode = int.Parse(nodeAsStringBuilder.ToString());
                        if (used[newNode]) continue;
                        if (isForbiddenEdge[newNode]) continue;
                        // the new node is not visited and is not forbidden, so add it in the queue
                        used[newNode] = true;
                        nextLevelNodes.Enqueue(newNode);
                    }
                }
                nodesQueue = nextLevelNodes;
            }
            return -1;
        }
    }
    /*
    00000
    65536
    6
    00001
    00010
    00100
    01000
    10000
    99999
     * 
     * 
    88056
    86508
    5
    88057
    88047
    85508
    87508
    86408
    */
}