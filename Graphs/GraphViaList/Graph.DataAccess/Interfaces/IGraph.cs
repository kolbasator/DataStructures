﻿using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IGraph<T>
    {
        int GetSize();
        void AddVertex(T data);
        void RemoveVertex(T data);
        void AddEdge(T firstVertex, T secondVertex);
        void RemoveEdge(T firstVertex, T secondVertex);
        bool AreAdjacent(T firstVertex, T secondVertex);
        List<IVertex<T>> GetVertices();
        List<IVertex<T>> GetNeighbours(T vertex);
    }
}
