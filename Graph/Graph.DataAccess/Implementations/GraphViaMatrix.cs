using System.Collections.Generic;
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class GraphViaMatrix<T> : IGraphViaMatrix<T>
    {   
        private List<IGraphViaMatrixVertex<T>> _vertices { get; set; }
        private int[,] _matrix { get; set; }
        private int _iterator { get; set; }
        private int _maxNumberOfVertices { get; set; }
        public GraphViaMatrix(int maxNumberOfVertices)
        {
            _matrix = new int[maxNumberOfVertices,maxNumberOfVertices];
            _vertices = new List<IGraphViaMatrixVertex<T>>();
            _iterator = 0;
            _maxNumberOfVertices = maxNumberOfVertices;
        }
        public int GetSize()
        {
            return _vertices.Count;
        }
        public void AddVertex(T data)
        {
            _vertices.Add(new GraphViaMatrixVertex<T>(data,_iterator));
            _iterator++;
        }
        public void RemoveVertex(T data)
        {
            var vertex = _vertices.FirstOrDefault(ver => ver.GetData().Equals(data));
            for(int i = 0; i < _maxNumberOfVertices; i++)
            {
                if (_matrix[i, vertex.GetIndex()] == 1)
                {
                    _matrix[i, vertex.GetIndex()] = 0;
                }
            }
            _vertices.Remove(vertex);
        } 
        public void AddEdge(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex)
        {
            _matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] = 1;
            _matrix[secondVertex.GetIndex(),firstVertex.GetIndex()] = 1;
        } 
        public void RemoveEdge(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex)
        {
            _matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] = 0;
            _matrix[secondVertex.GetIndex(), firstVertex.GetIndex()] = 0;
        } 
        public bool AreAdjacent(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex)
        {
            return _matrix[firstVertex.GetIndex(), secondVertex.GetIndex()] == 1;
        } 
        public List<IGraphViaMatrixVertex<T>> GetVertices()
        {
            return _vertices;
        } 
        public List<IGraphViaMatrixVertex<T>> GetNeighbours(IGraphViaMatrixVertex<T> vertex)
        {
            int index = vertex.GetIndex();
            List<IGraphViaMatrixVertex<T>> neighbours = new List<IGraphViaMatrixVertex<T>>();
            for (int i = 0; i < _maxNumberOfVertices; i++)
            {
                if (_matrix[i,index] == 1)
                {
                    neighbours.Add(_vertices.FirstOrDefault(ver => ver.GetIndex() == i));
                }
            }
            return neighbours;
        }
    }

}
