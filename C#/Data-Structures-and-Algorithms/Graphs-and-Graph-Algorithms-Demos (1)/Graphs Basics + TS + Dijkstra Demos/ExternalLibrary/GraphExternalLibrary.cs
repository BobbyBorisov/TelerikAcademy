using System;
using QuickGraph;

namespace Graphs
{
    public class GraphExternalLibrary
    {
        static void Main()
        {
            UndirectedGraph<int, Edge<int>> graph = new UndirectedGraph<int, Edge<int>>();
            
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);

            graph.AddEdge(new Edge<int>(1, 2));
            graph.AddEdge(new Edge<int>(3, 4));
            graph.AddEdge(new Edge<int>(1, 4));

            foreach (var edge in graph.Edges)
            {
                Console.WriteLine(edge.Source + " " + edge.Target);
            }
        }
    }
}
