using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedOOP
{
    public class Graph
    {
        internal IDictionary<string, Node> Nodes { get; private set; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        public void AddNode(string name)
        {
            var node = new Node(name);
            Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, int distance, bool twoWay)
        {
            Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var conection in node.Value.Connections)
                {
                    result.Append(conection.Target + "-" + conection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
