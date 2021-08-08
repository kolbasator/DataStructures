﻿using System;
using System.Collections.Generic; 
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        private List<IVertex<T>> _vertices;
        private int[,] _matrix;
        private int _iterator;
        private int _maxNumberOfVertices;
        public Graph(int maxNumberOfVertices)
        {
            _matrix = new int[maxNumberOfVertices, maxNumberOfVertices];
            _vertices = new List<IVertex<T>>();
            _iterator = 0;
            _maxNumberOfVertices = maxNumberOfVertices;
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
            var vertex = new Vertex<T>(data, _iterator);
            _vertices.Add(vertex);
            _iterator++;
            return vertex;
        }

        /// <summary>
        /// Adds an edge with the same weight between two vertices with such data.
        /// </summary> 
        public void AddEdge(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) && !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices does not exist.");
            var firstIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex();
            var secondIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex();
            _matrix[firstIndex, secondIndex]=1;
            _matrix[secondIndex, firstIndex]=1;
        }

        /// <summary>
        /// Adds an edge with the same weight between two vertices.
        /// </summary> 
        public void AddEdge(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) && !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices does not exist.");
            _matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] = 1;
            _matrix[secondVertex.GetIndex(), secondVertex.GetIndex()] = 1;
        }

        /// <summary>
        /// Removes a vertex with the same data.
        /// </summary> 
        public void RemoveVertex(T data)
        {
            if (!ContainsVertex(data))
                throw new Exception("Vertex does not exist.");
            var vertex = _vertices.FirstOrDefault(v => v.GetData().Equals(data));
            for (int i = 0; i < _maxNumberOfVertices; i++)
            {
                _matrix[i, vertex.GetIndex()] = 0;
                _matrix[vertex.GetIndex(), i] = 0;
            }
            _vertices.Remove(vertex);
        }

        /// <summary>
        /// Removes a vertex by reference. 
        /// </summary> 
        public void RemoveVertex(IVertex<T> vertex)
        {
            if (!_vertices.Contains(vertex))
                throw new Exception("Vertex does not exist.");
            for (int i = 0; i < _maxNumberOfVertices; i++)
            {
                _matrix[i, vertex.GetIndex()] = 0;
                _matrix[vertex.GetIndex(), i] = 0;
            }
            _vertices.Remove(vertex);
        }

        /// <summary>
        /// Removes edge between two vertices with such data, if such edge exists.
        /// </summary> 
        public void RemoveEdge(T firstVertex, T secondVertex)
        {
            if (!ContainsVertex(firstVertex) && !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices does not exist.");
            var firstIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex();
            var secondIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex();
            if (_matrix[firstIndex, secondIndex] == 0 || _matrix[secondIndex, firstIndex] == 0)
                throw new Exception("Vertices are not connected.");
            _matrix[firstIndex, secondIndex] = 0;
            _matrix[secondIndex, firstIndex] = 0;
        }

        /// <summary>
        /// Removes edge between two vertices , if such edge exists.
        /// </summary> 
        public void RemoveEdge(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) && !_vertices.Contains(secondVertex))
                throw new Exception("One or both vertices does not exist.");
            else if (_matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] == 0 || _matrix[secondVertex.GetIndex(), firstVertex.GetIndex()] == 0)
                throw new Exception("Vertices are not connected.");
            _matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] = 0;
            _matrix[secondVertex.GetIndex(), secondVertex.GetIndex()] = 0;
        }

        /// <summary>
        /// Clears the graph completely.
        /// </summary> 
        public void Reset()
        {
            _vertices.Clear();
            ClearEdges();
        }

        /// <summary>
        /// Removes all edges.
        /// </summary> 
        public void ClearEdges()
        {
            for (int i = 0; i < _maxNumberOfVertices; i++)
            {
                for (int j = 0; j < _maxNumberOfVertices; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
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
            if (!ContainsVertex(firstVertex) && !ContainsVertex(secondVertex))
                throw new Exception("One or both vertices do not exist.");
            var firstIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex();
            var secondIndex = _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex();
            return _matrix[firstIndex, secondIndex]==1 && _matrix[secondIndex, firstIndex] ==1;
        }

        /// <summary>
        /// Checks if these vertices are connected.
        /// </summary> 
        public bool AreAdjacent(IVertex<T> firstVertex, IVertex<T> secondVertex)
        {
            if (!_vertices.Contains(firstVertex) && !_vertices.Contains(secondVertex))
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
            var vertex = _vertices.FirstOrDefault(v => v.GetData().Equals(data));
            var neighbours = new List<IVertex<T>>();
            for (int i = 0; i < _maxNumberOfVertices; i++)
            { 
                if(_matrix[i, vertex.GetIndex()] ==1 && _matrix[vertex.GetIndex(), i] ==1)
                {
                    neighbours.Add(_vertices.FirstOrDefault(v => v.GetIndex() == i));
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
                throw new Exception("Vertex does not exist.");  
            var neighbours = new List<IVertex<T>>();
            for (int i = 0; i < _maxNumberOfVertices; i++)
            {
                if (_matrix[i, vertex.GetIndex()] == 1 && _matrix[vertex.GetIndex(), i] == 1)
                {
                    neighbours.Add(_vertices.FirstOrDefault(v => v.GetIndex() == i));
                }
            }
            return neighbours;
        }
    }

}