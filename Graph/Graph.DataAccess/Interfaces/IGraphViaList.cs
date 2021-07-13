using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IGraphViaList<T>
    {
        public int GetSize();
        public void AddVertex(T data);
        public void RemoveVertex(T data);
        public void AddEdge(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex);
        public void RemoveEdge(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex);
        public bool AreAdjacent(IGraphViaListVertex<T> firstVertex, IGraphViaListVertex<T> secondVertex);
        public List<IGraphViaListVertex<T>> GetVertices();
        public List<IGraphViaListVertex<T>> GetNeighbours(IGraphViaListVertex<T> vertex);
    }
}
