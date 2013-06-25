using System;

namespace DijkstraWithPriorityQueue
{
    public class Node : IComparable
    {
        public int ID { get; private set; }
        public double DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}
