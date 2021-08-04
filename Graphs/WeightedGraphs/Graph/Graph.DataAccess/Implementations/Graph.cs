﻿using System;
using System.Collections.Generic;
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        private List<IVertex<T>> _vertices;
        private List<IEdge<T>> _edges;
        public Graph()
        {
            _vertices = new List<IVertex<T>>();
            _edges = new List<IEdge<T>>(); 
        }

        /// <summary>
        /// Returns the size of the current graph. 
        /// </summary> 
        public int GetSize()
        {
            return _vertices.Count;
        }

        /// <summary>
        /// Adds a new vertex to the graph and returns a reference to it.
        /// </summary>  
        public IVertex<T> AddVertex(T data)
        {
            if (ContainsVertex(data))
                throw new Exception("Vertex has already been added.");
            var vertex = new Vertex<T>(data);
            _vertices.Add(vertex);
            return vertex;
        }

        /// <summary>
        /// Adds an edge with the same weight between two vertices with such data.
        /// </summary> 
        public IEdge<T> AddEdge(T firstVertex, T secondVertex, int weight)
        {
            if (!ContainsVertex(firstVertex) || !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var edge = new Edge<T>(_vertices.FirstOrDefault(v=>v.GetData().Equals(firstVertex)), _vertices.First(v=>v.GetData().Equals(secondVertex)), weight);
            _edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Adds an edge with the same weight between two vertices.
        /// </summary> 
        public IEdge<T> AddEdge(IVertex<T> firstVertex, IVertex<T> secondVertex, int weight)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var edge = new Edge<T>(firstVertex, secondVertex, weight);
            _edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Removes a vertex with the same data.
        /// </summary> 
        public void RemoveVertex(T data)
        {
            if (!ContainsVertex(data))
                throw new Exception("The vertex does not exist.");
            var vertexToRemove = _vertices.FirstOrDefault(v => v.GetData().Equals(data));
            var listOfIcidentEdges = _edges.Where(e => e.FirstVertex().Equals(vertexToRemove) || e.SecondVertex().Equals(vertexToRemove)).ToList();
            foreach (var edge in listOfIcidentEdges)
            {
                _edges.Remove(edge);
            }
            _vertices.Remove(vertexToRemove);
        }

        /// <summary>
        /// Removes a vertex by reference. 
        /// </summary> 
        public void RemoveVertex(IVertex<T> vertex)
        {
            if (!_vertices.Contains(vertex))
                throw new Exception("The vertex does not exist.");
            var vertexToRemove = _vertices.FirstOrDefault(v => v.Equals(vertex));
            var listOfIcidentEdges = _edges.Where(e => e.FirstVertex().Equals(vertexToRemove) || e.SecondVertex().Equals(vertexToRemove));
            foreach (var edge in listOfIcidentEdges)
            {
                _edges.Remove(edge);
            }
            _vertices.Remove(vertexToRemove);
        }

        /// <summary>
        /// Removes an edge by reference. 
        /// </summary> 
        public void RemoveEdge(IEdge<T> edge)
        {
            if (!ContainsEdge(edge))
                throw new Exception("Edge does not exist.");
            _edges.Remove(edge);
        }

        /// <summary>
        /// Removes edge between two vertices , if such edge exists.
        /// </summary> 
        public void RemoveEdge(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            else if (!AreAdjacent(firstVertex, secondVertex))
                throw new Exception("Vertices are not connected.");
            var edge = _edges.FirstOrDefault(e => e.FirstVertex().Equals(firstVertex) && e.SecondVertex().Equals(secondVertex));
        }

        /// <summary>
        /// Clears the graph completely.
        /// </summary> 
        public void Reset()
        {
            _vertices.Clear();
            _edges.Clear();
        }
        /// <summary>
        /// Removes all edges.
        /// </summary> 
        public void ClearEdges()
        {
            _edges.Clear();
        }

        /// <summary>
        /// Checks for the presence of a vertex with the same data in the graph. 
        /// </summary> 
        public bool ContainsVertex(T vertex)
        {
            return _vertices.FirstOrDefault(v => v.GetData().Equals(vertex)) != null;
        }

        /// <summary>
        /// Checks for the presence of this edge in the graph.
        /// </summary> 
        public bool ContainsEdge(IEdge<T> edge)
        {
            return _edges.Contains(edge);
        }

        /// <summary>
        /// Checks if vertices are connected with the same data.
        /// </summary>
        public bool AreAdjacent(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) || !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var edge = _edges.FirstOrDefault(e => (e.FirstVertex().GetData().Equals(firstVertex) && e.SecondVertex().GetData().Equals(secondVertex)));
            return edge != null;
        }

        /// <summary>
        /// Checks if these vertices are connected.
        /// </summary> 
        public bool AreAdjacent(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var edge = _edges.FirstOrDefault(e => (e.FirstVertex().Equals(firstVertex) && e.SecondVertex().Equals(secondVertex)));
            return edge != null;
        }

        /// <summary>
        /// Returns a list of all the vertices in the graph.
        /// </summary> 
        public List<IVertex<T>> GetVertices()
        {
            return _vertices;
        }

        /// <summary>
        /// Returns a list of all the edges in the graph.
        /// </summary> 
        public List<IEdge<T>> GetEdges()
        {
            return _edges;
        }

        /// <summary>
        /// Returns a list of all vertices adjacent to a vertex with such data.
        /// </summary> 
        public List<IVertex<T>> GetNeighbours(T data)
        {
            if (!ContainsVertex(data))
                throw new Exception("The vertex does not exist.");
            var neighbours = new List<IVertex<T>>();
            foreach (var edge in _edges)
            {
                if (edge.FirstVertex().GetData().Equals(data))
                {
                    neighbours.Add(edge.SecondVertex());
                }
                else if (edge.SecondVertex().GetData().Equals(data))
                {
                    neighbours.Add(edge.FirstVertex());
                }
            }
            return neighbours;
        }

        /// <summary>
        /// Returns a list of all vertices adjacent to this vertex.
        /// </summary>
        public List<IVertex<T>> GetNeighbours(IVertex<T> vertex)
        {
            if (!_vertices.Contains(vertex))
                throw new Exception("The vertex does not exist.");
            var neighbours = new List<IVertex<T>>();
            foreach (var edge in _edges)
            {
                if (edge.FirstVertex().Equals(vertex))
                {
                    neighbours.Add(edge.SecondVertex());
                }
                else if (edge.SecondVertex().Equals(vertex))
                {
                    neighbours.Add(edge.FirstVertex());
                }
            }
            return neighbours;
        }
    }
}
