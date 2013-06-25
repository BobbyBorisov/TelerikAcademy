using System;

namespace DFSRecursiveOOPGraph
{
    public class RecursiveDFS
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(new int[][] {
                new int[] {3, 6}, // successors of vertice 0
                new int[] {2, 3, 4, 5, 6}, // successors of vertice 1
                new int[] {1, 4, 5}, // successors of vertice 2
                new int[] {0, 1, 5}, // successors of vertice 3
                new int[] {1, 2, 6}, // successors of vertice 4
                new int[] {1, 2, 3}, // successors of vertice 5
                new int[] {0, 1, 4}  // successors of vertice 6
            });

            graph.DFSRecursive(0);
        }
    }
}
