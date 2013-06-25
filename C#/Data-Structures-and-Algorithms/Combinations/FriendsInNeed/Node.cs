using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsInNeed
{
    public class Node : IComparable
    {
        public int ID { get; private set; }
        public int DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
            this.DijkstraDistance = int.MaxValue;
        }

        public Node(int id, int dijkstradistance)
        {
            this.ID = id;
            this.DijkstraDistance = dijkstradistance;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj as Node) == null) { return false; }
            bool isEqual = this.ID == (obj as Node).ID;
            return isEqual;
        }

        public override string ToString()
        {
            return this.ID.ToString();
        }
            
    }
}
