using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinarySearchTree.DataAccess.Implementations
{
    public class BinarySearchTreeClass : IBinarySearchTree
    {
        public INode Root { get; set; }
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
            INode nodeToDelete = Search(key);
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
        public INode Insert(int entity)
        {
            INode node = new Node(entity);
            if (Root == null)
            {
                Root = new Node(entity);
                return node;
            }
            INode previos = null;
            INode current = Root;
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
        public INode GetMax(INode current)
        {
            INode currentNode = current;
            while (currentNode.HasRightChild)
            {
                currentNode = currentNode.Right;
            }
            return current;
        }
        public INode GetMin(INode current)
        {
            INode currentNode = current;
            while (currentNode.HasLeftChild)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }
        public INode Search(int entity)
        {
            INode current = Root;
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
