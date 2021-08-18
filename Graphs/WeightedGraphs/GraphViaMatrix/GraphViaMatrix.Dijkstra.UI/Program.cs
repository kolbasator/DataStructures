using System;
using Graph.DataAccess.Interfaces;
using Graph.DataAccess.Implementations;
using Graph.DataAccess.Algorithms; 

namespace Graph.Dijkstra.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dijkstra method example: ");

            IGraph<char> graph = new Graph<char>(15);
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            var f = graph.AddVertex('F');
            var g = graph.AddVertex('G');

            graph.AddEdge(a, b, 5);

            graph.AddEdge(a, d, 18);

            graph.AddEdge(a, f, 8);

            graph.AddEdge(f, d, 9);

            graph.AddEdge(f, c, 8);

            graph.AddEdge(d, c, 9);

            graph.AddEdge(d, e, 4);

            graph.AddEdge(d, g, 7);

            graph.AddEdge(e, g, 1);

            graph.AddEdge(c, g, 9);

            var shortestPathTable = new DijkstraAlgorithm<char>().Dijkstra(graph, a);

            foreach (var path in shortestPathTable)
            {
                Console.WriteLine(path.GetData());
            }
        }
    }
}
