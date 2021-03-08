using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeClass : IBinaryTree
    {
        public Node Root { get; set; }
        public string Postfix { get; set; }
        public string Infix { get; set; } 
        public BinaryTreeClass(Node key)
        {
            Root =key;
        }

        public BinaryTreeClass()
        {
            Root = null;
        }
        public void InOrder(Node temp)
        {
            if (temp != null)
            {
                InOrder(temp.Left);
                Infix += temp.Value;
                InOrder(temp.Right);
            }
        }
        public void PostOrder(Node temp)
        {
            if (temp != null)
            {
                PostOrder(temp.Left); 
                PostOrder(temp.Right);
                Postfix += temp.Value;
            }
        }
    }
}
