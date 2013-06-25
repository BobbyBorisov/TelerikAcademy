using System;
using System.Collections.Generic;

namespace DijkstraWithPriorityQueue
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
                    node.Key.DijkstraDistance = double.PositiveInfinity;
                    queue.Enqueue(node.Key);
                }
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijkstraDistance == double.PositiveInfinity)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    double potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potDistance;
                    }
                }

                queue.Dequeue();
            }
        }

        static void Main()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);
            Node node8 = new Node(8);
            Node node9 = new Node(9);
            Node node10 = new Node(10);

            List<Node> nodes = new List<Node>();

            nodes.Add(node1);
            nodes.Add(node2);
            nodes.Add(node3);
            nodes.Add(node4);
            nodes.Add(node5);
            nodes.Add(node6);
            nodes.Add(node7);
            nodes.Add(node8);
            nodes.Add(node9);
            nodes.Add(node10);

            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>()
            {
                {node1, new List<Connection> {new Connection(node2, 23), new Connection(node8, 8)} },
                {node2, new List<Connection> {new Connection(node1, 23), new Connection(node4, 3), new Connection(node7, 34)} },
                {node3, new List<Connection> {new Connection(node4, 6), new Connection(node8, 25), new Connection(node10, 7)} },
                {node4, new List<Connection> {new Connection(node2, 3), new Connection(node3, 6)} },
                {node5, new List<Connection> {new Connection(node6, 10)} },
                {node6, new List<Connection> {new Connection(node5, 10)} },
                {node7, new List<Connection> {new Connection(node2, 34)} },
                {node8, new List<Connection> {new Connection(node1, 8), new Connection(node3, 25), new Connection(node10, 30)} },
                {node9, new List<Connection> {} },
                {node10, new List<Connection> {new Connection(node3, 7), new Connection(node8, 30)} },
            };

            Node source = node1;

            DijkstraAlgorithm(graph, source);

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("Distance from {0} to {1} ", source.ID, i);
                Console.WriteLine(nodes[i].DijkstraDistance);
            }
        }
    }
}
