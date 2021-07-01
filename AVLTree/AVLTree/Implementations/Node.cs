using System; 
using AVLTree.Interfaces;

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
            if (node == null)
                return 0;
            return GetHeight(node.Right) - GetHeight(node.Left);
        }

        public int GetHeight(INode node)
        {
            if (node == null) 
                return -1;
            if (node.HasNoChild)
                return 0;
            int left = GetHeight(node.Left);
            int right = GetHeight(node.Right);
            return (left > right ? left : right) + 1;
        }

        public void FixHeight(INode node)
        {
            node.Height = GetHeight(node);
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
        public INode RotateLeft(INode node)
        {
            var newRoot = node.Right;
            node.Right= newRoot.Left;
            newRoot.Left = node;
            FixHeight(node);
            FixHeight(newRoot);
            return newRoot;
        }

        public INode HeavyLeftRotate(INode node)
        {
            node.Right = RotateRight(node.Right); 
            return RotateLeft(node);
        }

        public INode HeavyRightRotate(INode node)
        {
            node.Left = RotateLeft(node.Left); 
            return RotateRight(node);
        }

        public INode Balance(INode node)
        {
            FixHeight(node);
            if (BalanceFactor(node) > 1)
            {
                if (BalanceFactor(node.Right) < 0)
                {
                    return HeavyLeftRotate(node);
                }
                return RotateLeft(node);
            }
            else if (BalanceFactor(node) < -1)
            {
                if (BalanceFactor(node.Left) > 0)
                {
                    return HeavyRightRotate(node);
                }
                return RotateRight(node);
            }
            return node;
        }
        public string InOrderTraverse(INode node)
        {
            BSTTraversalEngine.InOrderEngine(node);
            var resultList = BSTTraversalEngine.Infix;
            var resultString = string.Join(" ", resultList); 
            BSTTraversalEngine.Infix.Clear();
            return resultString;
        }
        public string PostOrderTraverse(INode node)
        {
            BSTTraversalEngine.PostOrderEngine(node);
            var resultList = BSTTraversalEngine.Postfix;
            var resultString = string.Join(" ", resultList); 
            BSTTraversalEngine.Postfix.Clear();
            return resultString;
        }
        public string PreOrderTraverse(INode node)
        {
            BSTTraversalEngine.PreOrderEngine(node);
            var resultList = BSTTraversalEngine.Prefix;
            var resultString = string.Join(" ", resultList);
            BSTTraversalEngine.Prefix.Clear();
            return resultString;
        }
        public INode Search(INode node,int key)
        {
            INode current = node;
            while (current != null && current.Key!=key)
            {
                if (key < current.Key)
                {
                    current = current.Left;
                }
                else 
                {
                    current = current.Right;
                }
            }
            return current;
        }

        public INode Insert(INode node, int key)
        {
            if (node == null) 
                return new Node(key);
            if (node.Key > key)
                node.Left = Insert(node.Left, key);
            else
                node.Right = Insert(node.Right, key);
            return Balance(node);
        }
        public INode GetMax(INode node)
        {
            return node.Right == null ? node : GetMax(node.Right);
        }
        public INode GetMin(INode node)
        {
            return node.Left == null ? node : GetMin(node.Left);
        }
        public INode GetParent(int key)
        {
            var current = Root;
            INode parent = null;
            while (current.Key!=key)
            {  
                if (key < current.Key)
                { 
                    parent = current;
                    current = current.Left;
                }
                else if (key > current.Key)
                { 
                    parent =current;
                    current = current.Right;
                }
            }
            return parent;
        }  
        public INode Remove(INode node, int key)
        {
            if (node.Key > key)
                node.Left = Remove(node.Left, key);
            else if (node.Key < key)
                node.Right = Remove(node.Right, key);
            else
            {
                if (node.HasNoChild) 
                    return null; 
                else if(node.HasLeftChild || node.HasRightChild) 
                    return node.Right == null ? node.Left : node.Right;  
                else if (!node.HasNoChild)
                {
                    var min = GetMin(node.Right);
                    int minValue=min.Key;
                    node.Key = minValue;
                    node.Right = Remove(node.Right,minValue);
                    return node; 
                }
            }
            return Balance(node); 
        }
    }
}
