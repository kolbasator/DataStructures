using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private bool _isVisited;
        private int _distanceFromStart; 
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

        /// <summary>
        ///  Returns the price of the shortest path to this vertex from the start.
        /// </summary> 
        public int GetDistance()
        {
            return _distanceFromStart;
        }

        /// <summary>
        /// Changes the price of the shortest path to this vertex from the start to the specified one.
        /// </summary> 
        public void SetDistance(int dist)
        {
            _distanceFromStart = dist;
        } 
    }
}
