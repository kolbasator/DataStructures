using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IGraph<T>
    {
        int GetSize();
        void AddVertex(T data);
        void RemoveVertex(T data);
        List<IVertex<T>> GetVertices();
        List<IVertex<T>> GetNeighbours(T vertex);
        void AddEdge(T firstVertex, T secondVertex);
        void RemoveEdge(T firstVertex, T secondVertex);
        bool AreAdjacent(T firstVertex, T secondVertex); 
    }
}
