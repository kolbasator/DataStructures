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
            head.Previous = node;
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
                _count++;
                return First;
            }
            SetHeadLast(First, new LinkedListNode<T>(entity));
            SetTail(First);
            _count++;
            return new LinkedListNode<T>(entity);
        }
        public void RemoveFirst()
        {
            var newHead = First.Next;
            newHead.Previous = null;
            First = newHead;
            SetTail(First);
            _count--;
        }
        private void SetFindProperty(ILinkedListNode<T> item, T entity)
        {
            if (item == null)
            {
                _findResult = null; 
            }
            else if (item.Data.Equals(entity))
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
            SetContains(First, entity);
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
                current.Previous = next;
                previos = current;
                current = next;

            }
            First = previos;
            SetTail(First);
        }
        private void SetContains(ILinkedListNode<T> item, T entity)
        {
            if (item == null)
            {
                _contains = false;
            }
            else if (item.Data.Equals(entity))
            {
                _contains = true;
            }
            else
                SetContains(item.Next, entity);
        }
        private void DeleteLast(ILinkedListNode<T> item)
        {
            if (item.Next == null)
            {
                var newLast = _items[_items.Count - 1];
                newLast.Next = null;
                Last = newLast;
                First = _items[0];
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
                Last.Previous = item.Previous;
            }
            else
                SetTail(item.Next);
        }
        private void SetHeadLast(ILinkedListNode<T> item, ILinkedListNode<T> node)
        {
            if (item.Next == null)
            {
                node.Previous = item;
                item.Next = node;
            }
            else
                SetHeadLast(item.Next, node);
        }
        public void Clear()
        {
            First = null;
            Last = null;
            _count = 0;
        }
    }
}
