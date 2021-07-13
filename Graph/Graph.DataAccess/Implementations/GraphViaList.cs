using System;
using System.Collections.Generic;
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class GraphViaList<T> : IGraphViaList<T>
    {
        private List<IGraphViaListVertex<T>> _vertices { get; set; }
        public GraphViaList()
        {
            _vertices = new List<IGraphViaListVertex<T>>();
        }
        public GraphViaList(List<IGraphViaListVertex<T>> vertices)
        {
            _vertices = vertices;
        }
        public int GetSize()
        {
            return _vertices.Count;
        }
        public void AddVertex(T data)
        {
            _vertices.Add(new GraphViaListVertex<T>(data));
        }
        public void RemoveVertex(T data)
        {
            var vertex = _vertices.FirstOrDefault(ver => ver.GetData().Equals(data));
            var neighbours = vertex.GetHeighbours();
            foreach (var neighbour in neighbours)
            {
                neighbour.RemoveEdge(vertex);
            }
            _vertices.Remove(vertex);
        }
        public void AddEdge(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex)
        {
            firstVertex.AddEdge(secondVertex);
            secondVertex.AddEdge(firstVertex);
        }
        public void RemoveEdge(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex)
        {
            firstVertex.RemoveEdge(secondVertex);
            secondVertex.RemoveEdge(firstVertex);
        }
        public bool AreAdjacent(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex)
        {
            return firstVertex.HasNeighbour(secondVertex)&&secondVertex.HasNeighbour(firstVertex);
        }
        public List<IGraphViaListVertex<T>> GetVertices()
        {
            return _vertices;
        }
        public List<IGraphViaListVertex<T>> GetNeighbours(IGraphViaListVertex<T> vertex)
        {
            return vertex.GetHeighbours();
        }
    }
}
