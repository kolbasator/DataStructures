using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryMinHeap
{
    public interface IBinaryMinHeap
    {
        List<int> Items { get; set; }
        void Insert(int entity);
        int GetMin();
        int ExtractMin();
    }
}
