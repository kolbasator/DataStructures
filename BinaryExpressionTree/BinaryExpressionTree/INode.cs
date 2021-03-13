using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryExpressionTree
{
    public interface INode
    {
        string Status { get; set; }
        string Value { get; set; }
        INode LeftChild { get; set; } 
        INode RightChild { get; set; }  
    }
}
