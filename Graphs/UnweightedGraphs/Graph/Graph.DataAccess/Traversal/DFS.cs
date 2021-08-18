using System;
using System.Collections.Generic;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Traversal
{
    public class DFS<T>
    {
        public void DepthFirstSearchRecursive(IGraph<T> graph, IVertex<T> start)
        {
            foreach (var vertex in graph.GetVertices())
                vertex.UnVisit();
            DFSRecursive(graph,start);
        }
        public void DepthFirstSearchIterative(IGraph<T> graph, IVertex<T> start)
        {
            foreach (var vertex in graph.GetVertices())
                vertex.UnVisit();
            var stack = new Stack<IVertex<T>>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!current.IsVisited())
                {
                    current.Visit();
                    Console.Write(current.GetData() + " ");
                    foreach (var vertex in graph.GetUnvisitedNeighbours(current))
                        stack.Push(vertex);
                }
            }
        }
        private void DFSRecursive(IGraph<T> graph,IVertex<T> current)
        {
            if (!current.IsVisited())
            {
                current.Visit();
                Console.Write(current.GetData() + " ");
                foreach (var vertex in graph.GetUnvisitedNeighbours(current))
                    DFSRecursive(graph,vertex);
            }
        }
    }
}
