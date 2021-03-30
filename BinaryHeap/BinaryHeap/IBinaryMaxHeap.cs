using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryHeap
{
    public interface IBinaryMaxHeap
    {
        List<int> Items { get; set; }
        void Insert(int entity);
        int GetMax();
        int ExtractMax(); 

    }
}
