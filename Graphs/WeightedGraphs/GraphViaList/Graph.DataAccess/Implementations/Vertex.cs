using System.Linq;
using System.Collections.Generic; 
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private List<IAdjListNode<T>> _neighbours;
        private bool _isVisited;
        public Vertex(T data)
        {
            _data = data;
            _neighbours = new List<IAdjListNode<T>>();
        }  
        public Vertex(T data,List<IAdjListNode<T>> neighbours)
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
            return _neighbours.Any(n => n.GetNeighbour().Equals(vertex));
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
        public void AddEdge(IVertex<T> vertex,int weight)
        {
            _neighbours.Add(new AdjListNode<T>(vertex,weight));
        }

        /// <summary>
        /// Removes that vertex from list of neighbours of this vertex.   
        /// </summary> 
        public void RemoveEdge(IVertex<T> vertex)
        {
            _neighbours.Remove(_neighbours.FirstOrDefault(n=>n.GetNeighbour().Equals(vertex))); 
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
        public List<IAdjListNode<T>> GetNeighbours()
        {
            return _neighbours;
        }

        /// <summary>
        /// Returns list of all unvisited neighbours of this vertex.
        /// </summary>  
        public List<IAdjListNode<T>> GetUnvisitedNeighbours()
        {
            return _neighbours.Where(n=>!n.GetNeighbour().IsVisited()).ToList();
        }
    }
}
