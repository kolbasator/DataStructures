using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Edge<T> : IEdge<T>
    {
        private IVertex<T> _firstVertex;
        private IVertex<T> _secondVertex;
        private int _weight;
        public Edge(IVertex<T> firstVertex,IVertex<T> secondVertex,int weight)
        {
            _firstVertex = firstVertex;
            _secondVertex = secondVertex;
            _weight = weight;
        }

        /// <summary>
        /// Returns the weight.
        /// </summary> 
        public int GetWeight()
        {
            return _weight;
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
