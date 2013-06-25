using System;

namespace AdvancedOOP
{
    internal class Edge
    {
        internal Node Target { get; private set; }
        internal double Distance { get; private set; }

        internal Edge(Node target, double distance)
        {
            this.Target = target;
            this.Distance = distance;
        }
    }
}
