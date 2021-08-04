using System.Collections.Generic; 
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private List<IVertex<T>> _neighbours;
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
        public T GetData()
        {
            return _data;
        } 
        public int GetDegree()
        {
            return _neighbours.Count; 
        }
        public bool HasNeighbour(IVertex<T> vertex)
        {
            return _neighbours.Contains(vertex);
        }
        public List<IVertex<T>> GetHeighbours()
        {
            return _neighbours;
        }  
        public void AddEdge(IVertex<T> vertex)
        {
            _neighbours.Add(vertex);
        }
        public void RemoveEdge(IVertex<T> vertex)
        {
            _neighbours.Remove(vertex); 
        }
    }
}
