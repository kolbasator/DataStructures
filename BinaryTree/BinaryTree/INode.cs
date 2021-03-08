using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public interface INode
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
}
}
