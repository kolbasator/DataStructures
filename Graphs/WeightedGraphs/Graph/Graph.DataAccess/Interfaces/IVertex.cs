namespace Graph.DataAccess.Interfaces
{
    public interface IVertex<T>
    {
        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        T GetData();

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
    }
}
