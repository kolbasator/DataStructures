using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryExpressionTree
{
    public interface IBinaryExpressionTree
    {
        string Infix { get; set; }
        string Postfix { get; set; }
        INode Root { get; set; }
        double Calculate();
        string InOrderTraverse();
        string PostOrderTraverse();
    }
}
