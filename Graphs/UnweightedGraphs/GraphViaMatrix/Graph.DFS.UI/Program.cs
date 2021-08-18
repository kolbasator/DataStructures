using System;
using Graph.DataAccess.Interfaces;
using Graph.DataAccess.Implementations;
using Graph.DataAccess.Traversal;

namespace Graph.DFS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DFS example:");

            IGraph<char> graph = new Graph<char>(15);
            var dfs = new DFS<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            var f = graph.AddVertex('F');
            var g = graph.AddVertex('G');

            graph.AddEdge(a, b);

            graph.AddEdge(a, d);

            graph.AddEdge(a, f);

            graph.AddEdge(f, d);

            graph.AddEdge(f, c);

            graph.AddEdge(d, c);

            graph.AddEdge(d, e);

            graph.AddEdge(d, g);

            graph.AddEdge(e, g);

            graph.AddEdge(c, g);

            Console.Write("Iterative:");

            dfs.DepthFirstSearchIterative(graph, a);

            Console.Write("Recursive:");

            dfs.DepthFirstSearchRecursive(graph, a);
        }
    }
}
