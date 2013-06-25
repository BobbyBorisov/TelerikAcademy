using System;
using System.Collections.Generic;

namespace TSUsingSourceDFS
{
    public class DFSTS
    {
        static void Main()
        {
            int[,] matrix = new int[6, 6]
            {
                {0,1,0,0,1,0},
                {0,0,1,1,0,0},
                {0,0,0,1,0,0},
                {0,0,0,0,1,1},
                {0,0,0,0,0,1},
                {0,0,0,0,0,0},
            };

            Graph g = new Graph(matrix);
            g.TestDfs();
            g.ShowSort();
        }
    }
}
