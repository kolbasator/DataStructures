using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class GraphViaMatrixVertex<T> : IGraphViaMatrixVertex<T>
    {
        private T _data { get; set; }
        private int _index { get; set; }
        public GraphViaMatrixVertex(T data, int index)
        {
            _data = data;
            _index = index;
        }
        public int GetIndex()
        {
            return _index;
        } 
        public T GetData()
        {
            return _data;
        }
    }
}
