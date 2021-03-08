using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public interface IBinaryTree
    {
        public Node Root { get; set; }
        public string Postfix { get; set; }
        public string Infix { get; set; }
    }
}
