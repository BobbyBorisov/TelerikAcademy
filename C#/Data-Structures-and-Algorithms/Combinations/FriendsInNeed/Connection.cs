using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsInNeed
{
    class Connection
    {
        public Node Node { get; set; }
        public int Distance { get; set; }

        public Connection(Node node, int distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
    }
}
