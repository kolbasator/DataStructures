using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree.Implementations
{
    public class Node : INode
    {
        public int Key { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public INode Root { get; set; }
        public int Height { get; set; }
        public bool HasLeftChild => Left == null;
        public bool HasRightChild => Right == null;
        public bool HasNoChild => HasLeftChild && HasRightChild;
        public Node(int key)
        {
            Key = key;
            Left = null;
            Right = null;
            Root = this;
            Height = 0;
        }
        public int BalanceFactor(INode node)
        {
            if (node.HasRightChild)
            {
                return 0;
            }
            return GetHeight(node.Right) - GetHeight(node.Left);
        }
        public int GetHeight(INode node)
        {
            if (node == null)
            {
                return -1;
            }
            if (node.HasNoChild)
            {
                return 0;
            }
            int right = GetHeight(node.Right);
            int left = GetHeight(node.Left);
            int greatest = right > left ? right : left;
            int height = greatest + 1;
            return height;
        }
        public void FixHeight(INode node)
        {
            node.Height = GetHeight(node);
        }
        public INode RotateLeft(INode node)
        {
            var newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            FixHeight(node);
            FixHeight(newRoot);
            return newRoot;
        }
        public INode RotateRight(INode node)
        {
            var newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            FixHeight(node);
            FixHeight(newRoot);
            return newRoot;
        }
        public INode RotateLeftRight(INode node)
        { 
        }
    }
}
