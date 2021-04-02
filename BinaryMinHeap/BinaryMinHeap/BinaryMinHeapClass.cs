using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryMinHeap
{
    public class BinaryMinHeapClass : IBinaryMinHeap
    {
        public List<int> Items { get; set; }
        public int Size => Items.Count;
        private void Swap(int firstIndex, int secondIndex)
        {
            int first = Items[firstIndex];
            int second = Items[secondIndex];
            Items[firstIndex] = second;
            Items[secondIndex] = first;
        }
        private void Heapify(int index)
        {
            int smallest = index;
            if (2 * index + 1 < Size && Items[2 * index + 1] < Items[smallest])
                smallest = 2 * index + 1;
            if (2 * index + 2 < Size && Items[2 * index + 2] < Items[smallest])
                smallest = 2 * index + 2;
            if (smallest != index)
            {
                Swap(index, smallest);
                Heapify(smallest);
            }
        }
        private void SiftUp(int index)
        {
            int parent = index / 2;
            if (Items[parent] > Items[index])
            {
                Swap(index, parent);
                SiftUp(parent);
            }
        }
        public BinaryMinHeapClass(int[] items)
        {
            Items = items.ToList();
            for (int i = (Size / 2) - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        public int GetMin()
        {
            return Items[0];
        }
        public void Insert(int entity)
        {
            if (Size == 0)
            {
                Items = new List<int>();
                Items.Add(entity);
            }
            else
            {
                Items.Add(entity);
                SiftUp(Size - 1);
            }
        }
        public int ExtractMin()
        {
            if (Size == 0)
                throw new Exception("Heap empty");
            int output = Items[0];
            Items[0] = Items[Size - 1];
            Items.RemoveAt(Size - 1);
            Heapify(0);
            return output;
        }
    }
}
