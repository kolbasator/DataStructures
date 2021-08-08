using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IVertex<T>
    {  
        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        T GetData(); 

        /// <summary>
        /// Returns degree of this vertex.
        /// </summary> 
        int GetDegree();

        /// <summary>
        /// Checks if vertex has neighbour which equals this vertex.
        /// </summary> 
        bool HasNeighbour(IVertex<T> vertex);

        /// <summary>
        /// Sets the status to visited.
        /// </summary>
        void Visit();

        /// <summary>
        /// Sets the status to unvisited
        /// </summary>
        void UnVisit();

        /// <summary>
        /// Checks the visited vertex or not
        /// </summary> 
        bool IsVisited();

        /// <summary>
        /// Adds that vertex into list of neighbours of this vertex. 
        /// </summary> 
        void AddEdge(IVertex<T> vertex,int weight);

        /// <summary>
        /// Removes that vertex from list of neighbours of this vertex.   
        /// </summary> 
        void RemoveEdge(IVertex<T> vertex);

        /// <summary>
        /// Clears list of neighbours of this vertex.
        /// </summary>
        void ClearNeighbours(); 

        /// <summary>
        /// Returns list of all neighbours of this vertex.
        /// </summary> 
        List<IAdjListNode<T>> GetNeighbours();

        /// <summary>
        /// Returns list of all unvisited neighbours of this vertex.
        /// </summary> 
        List<IAdjListNode<T>> GetUnvisitedNeighbours();
    }
}
