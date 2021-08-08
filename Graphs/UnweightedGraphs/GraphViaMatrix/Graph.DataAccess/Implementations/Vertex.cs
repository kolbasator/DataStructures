using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private int _index;
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
    }
}
