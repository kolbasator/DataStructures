using System;
using System.Collections.Generic;
using System.Text;
using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        private T _data;
        private int _index;
        public Vertex(T data, int index)
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
