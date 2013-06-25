using Wintellect.PowerCollections;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
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

namespace FriendsInNeed
{
    public class Dijkstra
    {
        static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                if (source.ID != node.Key.ID)
                {
                    node.Key.DijkstraDistance = int.MaxValue;
                    queue.Enqueue(node.Key);
                }
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();


                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }


                foreach (var neighbour in graph[currentNode])
                {
                    int potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potDistance;
                        
                        Node next = new Node(neighbour.Node.ID, potDistance);
                        queue.Enqueue(next);
                    }
                }

                queue.Dequeue();
            }
        }
        
        static double currentdistance = 0;
        static HashSet<Node> hospitals;

        static void Main()
        {

            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfPoints = int.Parse(data[0]);
            int numberOfStreets = int.Parse(data[1]);
            int numberOfHospitals = int.Parse(data[2]);
            List<Node> nodes = new List<Node>();
            Dictionary<Node, List<Connection>> points = new Dictionary<Node, List<Connection>>();
            for (int i = 1; i <= numberOfPoints; i++)
            {
                var newNode = new Node(i);
                nodes.Add(newNode);
                points.Add(newNode, new List<Connection>());
            }

            string[] hospitalsData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            hospitals = new HashSet<Node>();
            for (int i = 0; i < numberOfHospitals; i++)
            {
                hospitals.Add(nodes[int.Parse(hospitalsData[i]) - 1]);
            }

            for (int i = 0; i < numberOfStreets; i++)
            {

                string[] connectionData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;

                Node firstNode = nodes[int.Parse(connectionData[0]) - 1];
                Node secondNode = nodes[int.Parse(connectionData[1]) - 1];

                Connection newConectedNode = new Connection(secondNode, int.Parse(connectionData[2]));
                Connection secondConectedNode = new Connection(firstNode, int.Parse(connectionData[2]));

                points[firstNode].Add(newConectedNode);
                points[secondNode].Add(secondConectedNode);

            }

            var best = int.MaxValue;
            
            foreach (var hospital in hospitals)
            {
                DijkstraAlgorithm(points, hospital);
                int result = 0;

                foreach (var path in points)
                {
                    if (!hospitals.Contains(path.Key))
                    {
                        result += path.Key.DijkstraDistance;
                    }
                }

                if (result < best) 
                {
                    best = result;
                }
                
            }

            Console.WriteLine(best);

        }
    }
}

namespace FriendsInNeed
{
    public class Node : IComparable
    {
        public int ID { get; private set; }
        public int DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
            //this.DijkstraDistance = int.MaxValue;
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

namespace FriendsInNeed
{
    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}

