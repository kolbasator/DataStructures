namespace Graph.DataAccess.Interfaces
{
    public interface IAdjListNode<T>
    {
        /// <summary>
        /// Returns weight of edge between to _vertices.
        /// </summary> 
        int GetWeight();

        /// <summary>
        /// Returns neighbour.
        /// </summary> 
        IVertex<T> GetNeighbour(); 
    }
}
