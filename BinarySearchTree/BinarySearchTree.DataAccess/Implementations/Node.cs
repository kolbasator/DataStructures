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
        public INode Root { get; set; }
        public int Value { get; set; }
        public bool HasLeftChild => Left != null;
        public bool HasRightChild => Right != null;
        public bool HasNoChild => Right == null && Left == null;
        public Node(int key)
        {
            Value = key;
            Root = this;
        } 
        public Node(INode left,INode right,int key)
        {
            Left = left;
            Right = right;
            Value = key;
        }
        public string InOrderTraverse()
        {
            BSTTraversalEngine.InOrderEngine(Root);
            var resultList = BSTTraversalEngine.Infix;
            var resultString = string.Join(" ", resultList); ;
            BSTTraversalEngine.Infix.Clear();
            return resultString;
        }
        public string PostOrderTraverse()
        {
            BSTTraversalEngine.PostOrderEngine(Root);
            var resultList = BSTTraversalEngine.Postfix;
            var resultString = string.Join(" ", resultList); ;
            BSTTraversalEngine.Postfix.Clear();
            return string.Join(" ", resultList); ;
        }
        public string PreOrderTraverse()
        {
            BSTTraversalEngine.PreOrderEngine(Root);
            var resultList = BSTTraversalEngine.Prefix;
            BSTTraversalEngine.Prefix.Clear();
            return string.Join(" ", resultList); ;
        }
        public void Delete(INode root, int key)
        {
            INode nodeToDelete = Search(key,root);
            INode parent = GetParent(nodeToDelete);
            if (nodeToDelete.HasNoChild)
            {
                if (parent.Left == nodeToDelete)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (nodeToDelete.Right == null || nodeToDelete.Left == null)
            {
                var child = nodeToDelete.Right == null ? nodeToDelete.Left : nodeToDelete.Right;
                if (nodeToDelete != Root)
                {
                    if (parent.Left == nodeToDelete)
                    {
                        parent.Left = child;
                    }
                    else
                    {
                        parent.Right = child;
                    }
                }
                else
                {
                    Root = child;
                }
            }
            else if (nodeToDelete.Right != null && nodeToDelete.Left != null)
            {
                var min = GetMin(nodeToDelete.Right);
                int value = min.Value;
                Delete(nodeToDelete.Right, min.Value);
                nodeToDelete.Value = value;
            }
        }
        public INode GetParent(INode node)
        {
            var current = Root;
            INode parent = null;
            while (current != node)
            {
                if (node.Value < current.Value)
                {
                    if (current.Left.Value == node.Value || current.Right.Value == node.Value)
                    {
                        parent = current;
                        break;
                    }
                    parent = new Node(current.Left, current.Right, current.Value);
                    current = current.Left;
                }
                else if (node.Value > current.Value)
                {
                    if (current.Left.Value == node.Value || current.Right.Value == node.Value)
                    {
                        parent = current;
                        break;
                    }
                    parent = new Node(current.Left, current.Right, current.Value);
                    current = current.Right;
                }
            }
            return parent;
        }
        public INode Insert(int entity,INode tree)
        {
            INode node = new Node(entity);
            if (tree == null)
            {
                tree = new Node(null,null,entity);
                return node;
            }
            INode previos = null;
            INode current = tree;
            while (current != null)
            {
                if (current.Value > entity)
                {
                    previos = current;
                    current = current.Left;
                }
                else if (current.Value < entity)
                {
                    previos = current;
                    current = current.Right;
                }
            }
            if (previos.Value > entity)
            {
                previos.Left = node;
            }
            else
            {
                previos.Right = node;
            }
            return node;
        }
        public INode GetMax(INode tree)
        {
            INode currentNode = tree;
            while (currentNode.HasRightChild)
            {
                currentNode = currentNode.Right;
            }
            return currentNode;
        }
        public INode GetMin(INode tree)
        {
            INode currentNode = tree;
            while (currentNode.HasLeftChild)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }
        public INode Search(int entity,INode tree)
        {
            INode current = tree;
            while (current != null && current.Value != entity)
            {
                if (entity < current.Value)
                {
                    current = current.Left;
                }
                else if (entity > current.Value)
                {
                    current = current.Right;
                }
            }
            return current;
        }
    }
}
