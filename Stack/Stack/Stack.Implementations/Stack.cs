using System;
using System.Collections.Generic;
using Stack.Interfaces;

namespace Stack.Implementations
{
    public class Stack<T> : IStack<T>
    {
        private List<T> _items;
        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }
        public Stack()
        {
            _items = new List<T>();
        }
        public void Push(T entity)
        {
            _items.Add(entity);
        }
        public T Peek()
        {
            return _items[Count-1];
        }
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("Stack is empty."); 
            }
            var item = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            return item;
        }
    }
}
