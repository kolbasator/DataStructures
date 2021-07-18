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
        private int[,] _matrix;
        private int _iterator;
        private int _maxNumberOfVertices;
        public Graph(int maxNumberOfVertices)
        {
            _matrix = new int[maxNumberOfVertices,maxNumberOfVertices];
            _vertices = new List<IVertex<T>>();
            _iterator = 0;
            _maxNumberOfVertices = maxNumberOfVertices;
        }
        public int GetSize()
        {
            return _vertices.Count;
        }
        public void AddVertex(T data)
        {
            if(data==null)
            {
                throw new Exception("Incorrect input.");
            }
            else if (_vertices.FirstOrDefault(v => v.GetData().Equals(data)) != null)
            {
                throw new Exception("Vertex has already been added.");
            }
            else
            {
                _vertices.Add(new Vertex<T>(data, _iterator));
                _iterator++;
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
                var vertex = _vertices.FirstOrDefault(ver => ver.GetData().Equals(data));
                for (int i = 0; i < _maxNumberOfVertices; i++)
                {
                    if (_matrix[i, vertex.GetIndex()] == 1)
                    {
                        _matrix[i, vertex.GetIndex()] = 0;
                    }
                }
                _vertices.Remove(vertex);
            } 
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
                _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex()] = 1;
                _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex()] = 1;
            }
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
            else if (!(GetNeighbours(secondVertex).Contains(_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex))) && GetNeighbours(firstVertex).Contains(_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)))))
            {
                throw new Exception("Vertices are not connected.");
            }
            else
            { 
                _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex()] = 0;
                _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex()] = 0;
            }
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
            else
            {
                return _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex()] == 1 && _matrix[_vertices.FirstOrDefault(v => v.GetData().Equals(secondVertex)).GetIndex(), _vertices.FirstOrDefault(v => v.GetData().Equals(firstVertex)).GetIndex()] == 1;
            }
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
            else
            {
                int index = _vertices.FirstOrDefault(v => v.GetData().Equals(vertex)).GetIndex();
                List<IVertex<T>> neighbours = new List<IVertex<T>>();
                for (int i = 0; i < _maxNumberOfVertices; i++)
                {
                    if (_matrix[i, index] == 1)
                    {
                        neighbours.Add(_vertices.FirstOrDefault(ver => ver.GetIndex() == i));
                    }
                }
                return neighbours;
            }
        }
    }

}
