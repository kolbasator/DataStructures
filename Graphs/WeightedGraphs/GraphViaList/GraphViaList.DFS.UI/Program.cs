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
             
            IGraph<char> graph = new Graph<char>();
            var dfs = new DFS<char>(); 
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

            Console.Write("Iterative:");

            dfs.DepthFirstSearchIterative(graph, a);

            Console.Write("Recursive:");

            dfs.DepthFirstSearchRecursive(graph, a);
        }
    }
}