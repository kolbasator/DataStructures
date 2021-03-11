using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public interface ILinkedListNode<T>
    {
        T Data { get; set; }
        ILinkedListNode<T> Next { get;set; }

    }
}
