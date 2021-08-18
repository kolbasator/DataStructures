using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private bool _isVisited;
        public Vertex(T data)
        {
            _data = data;
        }   

        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        public T GetData()
        {
            return _data;
        } 

        public void Visit()
        {
            _isVisited = true;
        }

        /// <summary>
        /// Sets the status to unvisited
        /// </summary>
        public void UnVisit()
        {
            _isVisited = false;
        }

        /// <summary>
        /// Checks the visited vertex or not
        /// </summary> 
        public bool IsVisited()
        {
            return _isVisited;
        } 
    }
}
