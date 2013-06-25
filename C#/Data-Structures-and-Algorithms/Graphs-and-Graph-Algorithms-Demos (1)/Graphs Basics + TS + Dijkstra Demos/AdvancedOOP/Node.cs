using System;
using System.Collections.Generic;

namespace AdvancedOOP
{
    internal class Node
    {
        IList<Edge> _connections;

        internal string Name { get; private set; }

        internal IEnumerable<Edge> Connections
        {
            get { return _connections; }
        }

        internal Node(string name)
        {
            Name = name;
            _connections = new List<Edge>();
        }

        internal void AddConnection(Node targetNode, double distance, bool twoWay)
        {
            if (targetNode == null) throw new ArgumentNullException("targetNode");
            if (targetNode == this)
                throw new ArgumentException("Node may not connect to itself.");
            if (distance <= 0) throw new ArgumentException("Distance must be positive.");

            _connections.Add(new Edge(targetNode, distance));
            if (twoWay) targetNode.AddConnection(this, distance, false);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}