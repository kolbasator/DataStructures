using System;
using System.Collections.Generic;
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        private List<IVertex<T>> _vertices;
        public Graph()
        {
            _vertices = new List<IVertex<T>>();
        }
        public Graph(List<IVertex<T>> vertices)
        {
            _vertices = vertices;
        }

        /// <summary>
        /// Returns the size of the current graph. 
        /// </summary> 
        public int GetSize()
        {
            return _vertices.Count();
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
        public void AddEdge(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) || !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var first = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex));
            var second = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex));
            first.AddEdge(second);
            second.AddEdge(first);
        }

        /// <summary>
        /// Adds an edge with the same weight between two vertices.
        /// </summary> 
        public void AddEdge(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            firstVertex.AddEdge(secondVertex);
            secondVertex.AddEdge(firstVertex);
        }

        /// <summary>
        /// Removes a vertex with the same data.
        /// </summary> 
        public void RemoveVertex(T data)
        {
            if (!ContainsVertex(data))
                throw new Exception("Vertex does not exist.");
            _vertices.Remove(_vertices.FirstOrDefault(v => v.GetData().Equals(data)));
        }

        /// <summary>
        /// Removes a vertex by reference. 
        /// </summary> 
        public void RemoveVertex(IVertex<T> vertex)
        {
            if (!_vertices.Contains(vertex))
                throw new Exception("Vertex does not exist.");
            _vertices.Remove(vertex);
        }

        /// <summary>
        /// Removes edge between two vertices with such data , if such edge exists.
        /// </summary> 
        public void RemoveEdge(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) || !ContainsVertex(secondVertex))
                throw new Exception("One ore both vertices are not exist.");
            if (!AreAdjacent(firstVertex, secondVertex))
                throw new Exception("Vertices are not connected.");
            var first = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex));
            var second = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex));
            first.RemoveEdge(second);
            second.RemoveEdge(first);
        }

        /// <summary>
        /// Removes edge between two vertices , if such edge exists.
        /// </summary> 
        public void RemoveEdge(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One ore both vertices are not exist.");
            if (!AreAdjacent(firstVertex, secondVertex))
                throw new Exception("Vertices are not connected.");
            firstVertex.RemoveEdge(secondVertex);
            secondVertex.RemoveEdge(firstVertex);
        }

        /// <summary>
        /// Clears the graph completely.
        /// </summary> 
        public void Reset()
        {
            _vertices.Clear();
        }

        /// <summary>
        /// Removes all edges.
        /// </summary> 
        public void ClearEdges()
        {
            _vertices.ForEach(v => v.ClearNeighbours());
        }

        /// <summary>
        /// Checks for the presence of a vertex with the same data in the graph. 
        /// </summary> 
        public bool ContainsVertex(T data)
        {
            return _vertices.Any(v => v.GetData().Equals(data));
        }

        /// <summary>
        /// Checks if vertices are connected with the same data.
        /// </summary> 
        public bool AreAdjacent(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) || !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var first = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex));
            var second = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex));
            return first.HasNeighbour(second) && second.HasNeighbour(first);
        }

        /// <summary>
        /// Checks if these vertices are connected.
        /// </summary> 
        public bool AreAdjacent(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) || !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            return AreAdjacent(firstVertex.GetData(), secondVertex.GetData());
        }

        /// <summary>
        /// Returns a list of all the vertices in the graph.
        /// </summary> 
        public List<IVertex<T>> GetVertices()
        {
            return _vertices;
        }

        /// <summary>
        /// Returns a list of all vertices adjacent to a vertex with such data.
        /// </summary> 
        public List<IVertex<T>> GetNeighbours(T data)
        {
            if (!ContainsVertex(data))
                throw new Exception("Vertex does not exist.");
            return _vertices.FirstOrDefault(v => v.GetData().Equals(data)).GetNeighbours();
        }

        /// <summary>
        /// Returns a list of all vertices adjacent to this vertex.
        /// </summary> 
        public List<IVertex<T>> GetNeighbours(IVertex<T> vertex)
        {
            return vertex.GetNeighbours();
        }
    }
}
