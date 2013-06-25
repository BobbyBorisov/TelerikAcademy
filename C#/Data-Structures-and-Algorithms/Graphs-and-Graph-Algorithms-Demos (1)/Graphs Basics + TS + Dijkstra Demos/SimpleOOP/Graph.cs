using System;
using System.Collections.Generic;

namespace DFSRecursiveOOPGraph
{
    public class Graph
    {
        public List<int>[] childNodes;

        public Graph(List<int>[] nodes)
        {
            this.childNodes = nodes;
        }
    }
}
