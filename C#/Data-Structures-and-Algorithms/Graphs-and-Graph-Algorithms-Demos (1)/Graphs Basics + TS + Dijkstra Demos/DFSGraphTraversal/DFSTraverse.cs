using System;
using System.Collections.Generic;

namespace DFSGraphTraversal
{
    class DFSTraverse
    {
        static Dictionary<string, List<string>> graph;
        static HashSet<string> visited = new HashSet<string>();

        public static void DFS(string node)
        {
            Stack<string> nodes = new Stack<string>();
            nodes.Push(node);
            visited.Add(node);

            while (nodes.Count != 0)
            {
                string currentNode = nodes.Pop();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph[currentNode].Count; i++)
                {
                    if (!visited.Contains(graph[currentNode][i]))
                    {
                        nodes.Push(graph[currentNode][i]);
                        visited.Add(graph[currentNode][i]);
                    }
                }
            }
        }

        static void Main()
        {
            graph = new Dictionary<string, List<string>>()
            {
                {"sofiq", new List<string>() {"burgas", "varna", "plovdiv", "kyustendil"} },
                {"burgas", new List<string>() {"varna", "vidin", "gabrovo"} },
                {"plovdiv", new List<string>() {"burgas", "vidin", "gabrovo"} },
                {"gabrovo", new List<string>() {"sofiq"} },
                {"kyustendil", new List<string>() {"blagoevgrad", "sofiq", "dupnica"} },
                {"varna", new List<string>() {"sofiq", "burgas"} },
                {"vidin", new List<string>() {"plovdiv", "burgas"} },
                {"dupnica", new List<string>() {"kyustendil", "blagoevgrad"} },
                {"blagoevgrad", new List<string>() {"sofiq", "kyustendil", "dupnica"} },
            };

            DFS("burgas");
        }
    }
}
