using System;
using System.Collections.Generic;
using System.Text;
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
            else
            {
                _edges.Add(new Edge<T>(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)), _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex))));
            }
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
            else
            {
                _vertices.Add(new Vertex<T>(data));
            }
        }
        public bool AreAdjacent(T firstVertex, T secondVertex)
        {
            if (firstVertex == null || secondVertex == null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)) == null || _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)) == null)
            {
                throw new Exception("One or both vertices do not exist.");

            }
            else
            {
                return _edges.FirstOrDefault(e => (e.FirstVertex().GetData().Equals(firstVertex) && e.SecondVertex().GetData().Equals(secondVertex)) || (e.SecondVertex().GetData().Equals(firstVertex) && e.FirstVertex().GetData().Equals(secondVertex))) != null;
            }
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
            else
            {
                var neighbours = new List<IVertex<T>>();
                foreach (var edge in _edges)
                {
                    if (edge.FirstVertex().GetData().Equals(vertex))
                    {
                        neighbours.Add(edge.SecondVertex());
                    }
                    else if (edge.SecondVertex().GetData().Equals(vertex))
                    {
                        neighbours.Add(edge.FirstVertex());
                    }
                }
                return neighbours;
            }
        }
        public int GetSize()
        {
            return _vertices.Count;
        }
        public List<IVertex<T>> GetVertices()
        {
            return _vertices;
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
            else if (_edges.FirstOrDefault(e => (e.FirstVertex().GetData().Equals(firstVertex) && e.SecondVertex().GetData().Equals(secondVertex)) || (e.SecondVertex().GetData().Equals(firstVertex) && e.FirstVertex().GetData().Equals(secondVertex))) == null)
            {
                throw new Exception("Vertices are not connected.");
            }
            else
            {
                _edges.Remove(_edges.FirstOrDefault(e => (e.FirstVertex().GetData().Equals(firstVertex) && e.SecondVertex().GetData().Equals(secondVertex)) || (e.FirstVertex().GetData().Equals(secondVertex) && e.SecondVertex().GetData().Equals(firstVertex))));
            }
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
            else
            {
                _vertices.Remove(_vertices.FirstOrDefault(v => v.GetData().Equals(data)));
            }
        }
    }
}
