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
        /// Adds that vertex into list of neighbours of this vertex. 
        /// </summary> 
        void AddEdge(IVertex<T> vertex);

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
        List<IVertex<T>> GetNeighbours();
    }
}
