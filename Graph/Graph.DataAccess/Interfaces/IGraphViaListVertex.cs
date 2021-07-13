using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IGraphViaListVertex<T>
    {  
        T GetData(); 
        int GetDegree();
        bool HasNeighbour(IGraphViaListVertex<T> vertex);
        void AddEdge(IGraphViaListVertex<T> vertex);
        void RemoveEdge(IGraphViaListVertex<T> vertex);
        List<IGraphViaListVertex<T>> GetHeighbours();
    }
}
