using System;
using System.Collections.Generic;

namespace Dictionary
{
    class DictGraph
    {
        static void Main()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                string[] connection = line.Split(' ');

                string first = connection[0];
                string second = connection[1];

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

                line = Console.ReadLine();
            }

            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                for (int i = 0; i < node.Value.Count; i++)
                {
                    Console.Write(node.Value[i] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
