using System;
using System.Collections.Generic;
using System.Text;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        public Vertex(T data)
        {
            _data = data;
        }
        public T GetData()
        {
            return _data;
        }
    }
}
