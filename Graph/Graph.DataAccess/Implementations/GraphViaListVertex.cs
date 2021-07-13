using System.Collections.Generic; 
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class GraphViaListVertex<T> : IGraphViaListVertex<T>
    {
        private T _data { get; set; }
        private List<IGraphViaListVertex<T>> _neighbours { get; set; }
        public GraphViaListVertex(T data)
        {
            _data = data;
        }
        public GraphViaListVertex(T data,List<IGraphViaListVertex<T>> neighbours)
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
        public bool HasNeighbour(IGraphViaListVertex<T> vertex)
        {
            return _neighbours.Contains(vertex);
        }
        public List<IGraphViaListVertex<T>> GetHeighbours()
        {
            return _neighbours;
        }  
        public void AddEdge(IGraphViaListVertex<T> vertex)
        {
            _neighbours.Add(vertex);
        }
        public void RemoveEdge(IGraphViaListVertex<T> vertex)
        {
            _neighbours.Remove(vertex); 
        }
    }
}
