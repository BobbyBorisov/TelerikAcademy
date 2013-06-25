using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOut
{
    class Program
    {
        static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        static List<string> connectionsToCheck = new List<string>();
        static Dictionary<string, int> degrees = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var source = Console.ReadLine();

            var connectionsCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < connectionsCount; i++) 
            {
                var line = Console.ReadLine().Split(' ');
                var first = line[0];
                var second = line[1];

                if (!graph.ContainsKey(first)) 
                {
                    graph[first] = new List<string>();
                }

                graph[first].Add(second);

                if (!graph.ContainsKey(second))
                {
                    graph[second] = new List<string>();
                }

                graph[second].Add(first);
            }

            var count = int.Parse(Console.ReadLine());

            for (var j = 0; j < count; j++) 
            {
                connectionsToCheck.Add(Console.ReadLine());
            }

            BFS(source);
            foreach (var person in connectionsToCheck)
            {
                if (degrees.ContainsKey(person))
                {
                    output.AppendLine(degrees[person].ToString());
                }
                else 
                {
                    output.AppendLine("-1");
                }
            }

            Console.WriteLine(output.ToString());
        }
        static StringBuilder output = new StringBuilder();
        
        //BFS
        static void BFS(string source) 
        {
            
            Queue<Tuple<string, int>> nodes = new Queue<Tuple<string, int>>();
            HashSet<string> used = new HashSet<string>();

            nodes.Enqueue(new Tuple<string,int>(source,0));
            used.Add(source);

            while (nodes.Count > 0) 
            {
                var user = nodes.Dequeue();

                degrees.Add(user.Item1, user.Item2);

                if (graph.ContainsKey(user.Item1)) 
                {
                    foreach (var connection in graph[user.Item1]) 
                    {
                        if (!used.Contains(connection)) 
                        {
                            used.Add(connection);
                            nodes.Enqueue(new Tuple<string,int>(connection,user.Item2+1));
                        }
                    }
                }
            }

        }
    }
}
