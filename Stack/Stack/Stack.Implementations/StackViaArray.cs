using System;
using Stack.Interfaces;

namespace Stack.Implementations
{
    public class StackViaArray<T> : IStackViaArray<T>
    {
        private T[] _items;
        public bool IsEmpty => Count == 0;
        public bool IsFull => Count == _items.Length;
        public int Count { get; private set; }
        public StackViaArray(int length)
        {
            _items = new T[length];
        }
        public void Push(T entity)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Stack overflow");
            }
            _items[Count] = entity;
            Count++;
        }
        public T Peek()
        {
            return _items[Count - 1];
        }
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("Stack is empty.");
            }
            var index = --Count;
            var item = _items[index];
            _items[index] = default;
            return item;
        }
    }
}
