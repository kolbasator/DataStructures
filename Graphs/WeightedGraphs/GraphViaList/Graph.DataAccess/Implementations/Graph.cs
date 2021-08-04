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
        public int GetSize()
        {
            return _vertices.Count;
        }
        public void AddVertex(T data)
        {
            if (data == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(data)) != null)
            {
                throw new Exception("Vertex has already been added.");
            }
            _vertices.Add(new Vertex<T>(data));
        }
        public void RemoveVertex(T data)
        {
            if (data == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(data)) == null)
            {
                throw new Exception("The vertex does not exist.");
            }
            var vertex = _vertices.FirstOrDefault(ver => ver.GetData().Equals(data));
            var neighbours = vertex.GetHeighbours();
            foreach (var neighbour in neighbours)
            {
                neighbour.RemoveEdge(vertex);
            }
            _vertices.Remove(vertex);
        }
        public void AddEdge(T firstVertex, T secondVertex)
        {
            if (firstVertex == null || secondVertex == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)) == null || _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)) == null)
            {
                throw new Exception("One or both vertices do not exist.");
            }
            _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).AddEdge(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)));
            _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).AddEdge(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)));
        }
        public void RemoveEdge(T firstVertex, T secondVertex)
        {

            if (firstVertex == null || secondVertex == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)) == null || _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)) == null)
            {
                throw new Exception("One or both vertices do not exist.");
            }
            else if (!(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).HasNeighbour(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex))) && _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).HasNeighbour(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)))))
            {
                throw new Exception("Vertices are not connected.");
            }
            _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).RemoveEdge(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)));
            _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).RemoveEdge(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex))); 
        }
        public bool AreAdjacent(T firstVertex, T secondVertex)
        {
            if (firstVertex == null || secondVertex == null)
            {
                throw new Exception("Incorrect input.");
            }
            if (_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)) == null || _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)) == null)
            {
                throw new Exception("One or both vertices do not exist.");

            }
            return _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).HasNeighbour(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex))) && _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).HasNeighbour(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex))); 
        }
        public List<IVertex<T>> GetVertices()
        {
            return _vertices;
        }
        public List<IVertex<T>> GetNeighbours(T vertex)
        {
            if (vertex == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(vertex)) == null)
            {
                throw new Exception("The vertex does not exist.");
            }
            return _vertices.FirstOrDefault(v => v.GetData().Equals(vertex)).GetHeighbours()
        }
    }
}
