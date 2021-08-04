using System;
using System.Collections.Generic;
using System.Text;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Edge<T> : IEdge<T>
    {
        private IVertex<T> _first;
        private IVertex<T> _second;
        public Edge(IVertex<T> first,IVertex<T> second)
        {
            _first = first;
            _second = second;
        }
        public IVertex<T> FirstVertex()
        {
            return _first;
        }
        public IVertex<T> SecondVertex()
        {
            return _second;
        }
    }
}
