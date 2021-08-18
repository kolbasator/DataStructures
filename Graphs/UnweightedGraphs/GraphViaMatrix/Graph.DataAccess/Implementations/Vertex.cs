using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private int _index;
        private bool _isVisited;
        public Vertex(T data, int index)
        {
            _data = data;
            _index = index;
        }

        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        public T GetData()
        {
            return _data;
        }

        /// <summary>
        /// Returns index of this vertex.
        /// </summary> 
        public int GetIndex()
        {
            return _index;
        }

        /// <summary>
        /// Sets the status to visited.
        /// </summary>
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
