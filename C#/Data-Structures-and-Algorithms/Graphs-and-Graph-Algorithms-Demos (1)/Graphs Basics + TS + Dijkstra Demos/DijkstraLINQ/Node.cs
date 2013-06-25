using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraLINQ
{
    internal class Node
    {
        private IList<Edge> connections;

        internal string Name { get; private set; }

        internal double DistanceFromStart { get; set; }

        internal IEnumerable<Edge> Connections
        {
            get { return connections; }
        }

        internal Node(string name)
        {
            Name = name;
            connections = new List<Edge>();
        }

        internal void AddConnection(Node targetNode, double distance, bool twoWay)
        {
            if (targetNode == null) throw new ArgumentNullException("targetNode");
            if (targetNode == this)
                throw new ArgumentException("Node may not connect to itself.");
            if (distance <= 0) throw new ArgumentException("Distance must be positive.");

            connections.Add(new Edge(targetNode, distance));
            if (twoWay) targetNode.AddConnection(this, distance, false);
        }
    }
}
