using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryExpressionTree
{
    public class Node : INode
    {
        public string Status { get; set; }
        public string Value { get; set; }
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; } 
        public Node(string symbol,INode left,INode right)
        {
            Value = symbol;
            LeftChild = left;
            RightChild = right;
            Status ="Operator";
        }
        public Node(string symbol)
        {
            Value = symbol; 
            Status = "Operand";
        }
    }
}
