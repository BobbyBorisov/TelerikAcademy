using System;

namespace DijkstraLINQ
{
    internal class Edge
    {
        internal Node Target { get; private set; }
        internal double Distance { get; private set; }

        internal Edge(Node target, double distance)
        {
            Target = target;
            Distance = distance;
        }
    }
}
