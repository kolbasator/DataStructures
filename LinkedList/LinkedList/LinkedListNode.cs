using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListNode<T> : ILinkedListNode<T>
    {
        public T Data { get; set; }
        public ILinkedListNode<T> Next { get; set; }
        public ILinkedListNode<T> Previous { get; set; }
        public LinkedListNode(T data)
        {
            Data = data;
        }
    }
}
