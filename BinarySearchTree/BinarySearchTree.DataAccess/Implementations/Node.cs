using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinarySearchTree.DataAccess.Implementations
{
    public class Node : INode
    {
        public INode Left { get; set; }
        public INode Right { get; set; }
        public int Value { get; set; }
        public bool HasLeftChild => Left != null;
        public bool HasRightChild => Right != null;
        public bool HasNoChild => Right == null && Left == null;
        public Node(int key)
        {
            Value = key;
        }
        public Node(INode left,INode right,int key)
        {
            Left = left;
            Right = right;
            Value = key;
        }
    }
}
