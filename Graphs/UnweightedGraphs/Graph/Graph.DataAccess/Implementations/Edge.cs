using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Edge<T> : IEdge<T>
    {
        private IVertex<T> _firstVertex;
        private IVertex<T> _secondVertex;
        public Edge(IVertex<T> firstVertex,IVertex<T> secondVertex)
        {
            _firstVertex = firstVertex;
            _secondVertex = secondVertex;
        } 

        /// <summary>
        /// Returns the first end vertex of an edge .
        /// </summary> 
        public IVertex<T> FirstVertex()
        {
            return _firstVertex;
        }

        /// <summary>
        /// Returns the second end vertex of an edge .
        /// </summary> 
        public IVertex<T> SecondVertex()
        {
            return _secondVertex;
        }
    }
}
