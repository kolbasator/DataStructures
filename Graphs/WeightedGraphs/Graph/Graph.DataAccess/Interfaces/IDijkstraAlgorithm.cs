using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IDijkstraAlgorithm<T>
    {
        /// <summary>
        /// Returns shortest path from start vertex to end vertex.
        /// </summary> 
        List<IVertex<T>> Dijkstra(IVertex<T> start, IVertex<T> end);
    }
}
