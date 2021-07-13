using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IGraphViaMatrix<T>
    {
        public int GetSize();
        public void AddVertex(T data);
        public void RemoveVertex(T data);
        public void AddEdge(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex);
        public void RemoveEdge(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex);
        public bool AreAdjacent(IGraphViaMatrixVertex<T> firstVertex, IGraphViaMatrixVertex<T> secondVertex);
        public List<IGraphViaMatrixVertex<T>> GetVertices();
        public List<IGraphViaMatrixVertex<T>> GetNeighbours(IGraphViaMatrixVertex<T> vertex);
    }
}
