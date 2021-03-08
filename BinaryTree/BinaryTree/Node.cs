using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node : INode
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(string item)
        {
            Value = item; 
        }
    }
}
