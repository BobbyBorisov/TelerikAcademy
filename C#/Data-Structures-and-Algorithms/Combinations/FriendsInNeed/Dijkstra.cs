using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

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
                    }
                }

                queue.Dequeue();
            }
        }
        static List<Node> nodes = new List<Node>();
        static List<Node> hospitals = new List<Node>();
       

        static void Main()
        {
            string line = Console.ReadLine();
            var splittedArgs = line.Split(' ');
            var nodesCount = int.Parse(splittedArgs[0]);
            var connectionCount = int.Parse(splittedArgs[1]);
            var hospitalCount = int.Parse(splittedArgs[2]);

            string secondLine = Console.ReadLine();
            var splitted = secondLine.Split(' ');

            for (var i = 0; i < splitted.Length; i++)
            {
                hospitals.Add(new Node(int.Parse(splitted[i]))); 
            }

            var graph = new Dictionary<Node,List<Connection>>();
            

            for (var j = 0; j < connectionCount; j++) 
            {
              var input = Console.ReadLine().Split(' ');
              var currentNodeFrom = new Node(int.Parse(input[0]));
              var currentNodeTo = new Node(int.Parse(input[1]));
              var currentWeight = int.Parse(input[2]);
               
              var currentConnection = new Connection(currentNodeTo,currentWeight);
               
              if (!graph.ContainsKey(currentNodeFrom)) 
              {
                  graph[currentNodeFrom] = new List<Connection>();
              }
              
              graph[currentNodeFrom].Add(currentConnection);


              if (!graph.ContainsKey(currentNodeTo)) 
              {
                  graph[currentNodeTo] = new List<Connection>();
              }

              graph[currentNodeTo].Add(new Connection(currentNodeFrom, currentWeight));
              
            }

            
            var list = new List<double>();
            foreach (var hospital in hospitals)
            {
                DijkstraAlgorithm(graph, hospital);
                double result = 0;

                foreach (var path in graph)
                {
                    if (!hospitals.Contains(path.Key))
                    {
                        result += path.Key.DijkstraDistance;
                    }
                }

                list.Add(result);
            }
            
            Console.WriteLine(list.Min());
            
        }
    }
}
