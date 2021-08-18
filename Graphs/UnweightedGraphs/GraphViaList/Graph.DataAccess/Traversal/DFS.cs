﻿using System;
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
            DFSRecursive(start);
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
                    foreach (var vertex in current.GetUnvisitedNeighbours())
                        stack.Push(vertex);
                }
            }
        }
        private void DFSRecursive(IVertex<T> current)
        {
            if (!current.IsVisited())
            {
                current.Visit();
                Console.Write(current.GetData() + " ");
                foreach (var vertex in current.GetUnvisitedNeighbours())
                    DFSRecursive(vertex);
            }
        }
    }
}
