using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IVertex<T>
    {  
        T GetData(); 
        int GetDegree();
        bool HasNeighbour(IVertex<T> vertex);
        void AddEdge(IVertex<T> vertex);
        void RemoveEdge(IVertex<T> vertex);
        List<IVertex<T>> GetHeighbours();
    }
}
