using System;
using Graph.DataAccess.Interfaces;
using Graph.DataAccess.Implementations;
using Graph.DataAccess.Algorithms;
using Graph.DataAccess.Models;
namespace Graph.Dijkstra.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dijkstra method example: ");

            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.AddEdge(a, b, 6);
            graph.AddEdge(b, a, 6);

            graph.AddEdge(a, d, 1);
            graph.AddEdge(d, a, 1);

            graph.AddEdge(d, e, 1);
            graph.AddEdge(e, d, 1);

            graph.AddEdge(d, b, 2);
            graph.AddEdge(b, d, 2);

            graph.AddEdge(e, b, 2);
            graph.AddEdge(b, e, 2);

            graph.AddEdge(e, c, 5);
            graph.AddEdge(c, e, 5);

            graph.AddEdge(c, b, 5);
            graph.AddEdge(b, c, 5);

            var shortestPathTable = new DijkstraAlgorithm<char>().Dijkstra(graph, a);

            foreach (var path in shortestPathTable)
            {
                Console.WriteLine(path.GetData());
            }
        }
    }
}
