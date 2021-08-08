namespace Graph.DataAccess.Interfaces
{
    public interface IEdge<T>
    { 
        /// <summary>
        /// Returns the first end vertex of an edge.
        /// </summary> 
        IVertex<T> FirstVertex();

        /// <summary>
        /// Returns the second end vertex of an edge. 
        /// </summary> 
        IVertex<T> SecondVertex(); 
    }
}
