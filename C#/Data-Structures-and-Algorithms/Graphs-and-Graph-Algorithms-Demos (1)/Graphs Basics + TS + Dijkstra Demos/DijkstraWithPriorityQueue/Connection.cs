using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraWithPriorityQueue
{
    public class Connection
    {
        public Node Node { get; set; }
        public double Distance { get; set; }

        public Connection(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
    }
}
