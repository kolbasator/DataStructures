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

        /// <summary>
        ///  Returns the price of the shortest path to this vertex from the start.
        /// </summary> 
        int GetDistance();

        /// <summary>
        /// Changes the price of the shortest path to this vertex from the start to the specified one.
        /// </summary> 
        void SetDistance(int dist);
    }
}
