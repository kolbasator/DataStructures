using System.Collections.Generic;
using System.Linq;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private List<IVertex<T>> _neighbours;
        private bool _isVisited;
        public Vertex(T data)
        {
            _data = data;
            _neighbours = new List<IVertex<T>>();
        }  
        public Vertex(T data,List<IVertex<T>> neighbours)
        {
            _data = data;
            _neighbours = neighbours;
        }

        /// <summary>
        /// Returns data of this vertex.
        /// </summary> 
        public T GetData()
        {
            return _data;
        } 

        /// <summary>
        /// Returns degree of this vertex.
        /// </summary> 
        public int GetDegree()
        {
            return _neighbours.Count; 
        }

        /// <summary>
        /// Checks if vertex has neighbour which equals this vertex.
        /// </summary> 
        public bool HasNeighbour(IVertex<T> vertex)
        {
            return _neighbours.Contains(vertex);
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
        /// Adds that vertex into list of neighbours of this vertex. 
        /// </summary> 
        public void AddEdge(IVertex<T> vertex)
        {
            _neighbours.Add(vertex);
        }

        /// <summary>
        /// Removes that vertex from list of neighbours of this vertex.   
        /// </summary> 
        public void RemoveEdge(IVertex<T> vertex)
        {
            _neighbours.Remove(vertex); 
        }

        /// <summary>
        /// Clears list of neighbours of this vertex.
        /// </summary>
        public void ClearNeighbours()
        {
            _neighbours.Clear();
        }

        /// <summary>
        /// Returns list of all neighbours of this vertex.
        /// </summary> 
        public List<IVertex<T>> GetNeighbours()
        {
            return _neighbours;
        }

        /// <summary>
        /// Returns list of all unvisited neighbours of this vertex.
        /// </summary> 
        public List<IVertex<T>> GetUnvisitedNeighbours()
        {
            return _neighbours.Where(n => !n.IsVisited()).ToList();
        }
    }
}
