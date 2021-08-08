namespace Graph.DataAccess.Interfaces
{
    public interface IVertex<T>
    { 
        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        T GetData(); 

        /// <summary>
        /// Returns index of this vertex.
        /// </summary> 
        int GetIndex();  
    }
}
