using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IGraph<T>
    {
        int GetSize();
        IVertex<T> AddVertex(T data);
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex); 
        void RemoveVertex(T data); 
        void RemoveEdge(IEdge<T> edge);  
        bool AreAdjacent(T firstVertex, T secondVertex);
        bool AreAdjacent(IVertex<T> firstVertex, IVertex<T> secondVertex);
        List<IVertex<T>> GetVertices();
        List<IVertex<T>> GetNeighbours(T vertex);

    }
}
