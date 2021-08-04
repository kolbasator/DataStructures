using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IGraph<T>
    {
        int GetSize();
        void AddVertex(T data);
        void AddEdge(T startVertex, T endVertex);
        void RemoveVertex(T data); 
        void RemoveEdge(T startVertex, T endVertex); 
        List<IVertex<T>> GetVertices();
        List<IVertex<T>> GetNeighbours(T vertex);  
        bool AreAdjacent(T startVertex, T endVertex); 
    }
}
