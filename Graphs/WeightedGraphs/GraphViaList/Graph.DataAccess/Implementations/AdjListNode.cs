using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class AdjListNode<T> : IAdjListNode<T>
    {
        private IVertex<T> _neighbour;
        private int _edgeWeight;
        public AdjListNode(IVertex<T> neighbour,int weight)
        {
            _neighbour = neighbour;
            _edgeWeight = weight;
        }

        /// <summary>
        /// Returns weight of edge between to _vertices.
        /// </summary> 
        public int GetWeight()
        {
            return _edgeWeight;
        }

        /// <summary>
        /// Returns neighbour.
        /// </summary> 
        public IVertex<T> GetNeighbour()
        {
            return _neighbour;
        }
    }
}
