using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListClass<T> : ILinkedList<T>
    {
        private int _count = 0;
        public bool IsEmpty => _count == 0;
        public int Count => _count;
        public ILinkedListNode<T> First { get; set; }
        public ILinkedListNode<T> Last { get; set; }
        private List<ILinkedListNode<T>> _items = new List<ILinkedListNode<T>>();
        private bool _contains { get; set; }
        private ILinkedListNode<T> _findResult { get; set; }
        public ILinkedListNode<T> AddFirst(T entity)
        { 
            if (First == null)
            {
                First = new LinkedListNode<T>(entity);
                _count++;
                return First;
            }
            var head = First;
            var node = new LinkedListNode<T>(entity);
            node.Next = head;
            First = node;
            SetTail(First);
            _count++;
            return new LinkedListNode<T>(entity);
        }
        public ILinkedListNode<T> AddLast(T entity)
        {
            if (First == null)
            {
                First = new LinkedListNode<T>(entity);
                return First;
            }
            SetHeadLast(First , new LinkedListNode<T>(entity));
            SetTail(First);
            _count++; 
            return new LinkedListNode<T>(entity);
        }
        public void RemoveFirst()
        {
            var newHead = First.Next;
            First = newHead;
            SetTail(First);
            _count--;
        }
        private void SetFindProperty(ILinkedListNode<T> item,T entity)
        {
            if (item.Data.Equals(entity))
            {
                _findResult = item;
            }
            else
            {
                SetFindProperty(item.Next, entity);
            }
        }
        public void RemoveLast()
        {
            DeleteLast(First);
        }
        public bool Contains(T entity)
        {
            SetContainsProperty(First, entity);
            var result = _contains;
            _contains = false;
            return result;

        }
        public ILinkedListNode<T> Find(T entity)
        {
            SetFindProperty(First, entity);
            var result = _findResult;
            _findResult = null;
            return result;
        }
        public void Reverse()
        {
            ILinkedListNode<T> previos = null, current = First, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previos;
                previos = current;
                current = next;
            }
            First = previos;
            SetTail(First);
        }
        private void SetContainsProperty(ILinkedListNode<T> item,T entity)
        { 
            if (item.Data.Equals(entity))
            {
                _contains = true;
            }
            else
            {
                SetContainsProperty(item.Next, entity);
            }
        }
        private void DeleteLast(ILinkedListNode<T> item)
        {
            if (item.Next  == null)
            { 
                Last = _items[_items.Count-1];
                First = _items[0];
                foreach(var element in _items)
                {
                    if (_items.IndexOf(element) != 0)
                    {
                        SetHeadLast(First, element); 
                    }
                }
                _items.Clear();
                _count--;
            }
            else
            {
                _items.Add(item);
                DeleteLast(item.Next);
            }
        }
        private void SetTail(ILinkedListNode<T> item)
        {
            if (item.Next == null)
            {
                Last = item;
            }
            else
            {
                SetTail(item.Next);
            }
        }
        private void SetHeadLast(ILinkedListNode<T> item,ILinkedListNode<T> node)
        {
            if (item.Next == null)
            {
                item.Next =node;

            }
            else
            {
                SetHeadLast(item.Next,node); 
            }
        }
        public void Clear()
        {
            First = null;
            Last = null;
            _count = 0;
        }
    }
}
