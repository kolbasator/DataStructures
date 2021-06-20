using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public interface INode
    {
        INode Left { get; set; }
        INode Right { get; set; }
        int Value { get; set; }
        bool HasRightChild { get;}
        bool HasLeftChild { get; } 
        bool HasNoChild { get; }
    }
}
