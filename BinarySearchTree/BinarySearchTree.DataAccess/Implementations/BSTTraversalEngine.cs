using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public static class BSTTraversalEngine
    {
        public static List<int> Infix = new List<int>();
        public static List<int> Postfix = new List<int>();
        public static List<int> Prefix = new List<int>();
        public static void InOrderEngine(INode root)
        {
            if (root != null)
            {
                InOrderEngine(root.Left);
                Infix.Add(root.Value);
                InOrderEngine(root.Right);
            }
        }
        public static void PostOrderEngine(INode root)
        {
            if (root != null)
            {
                InOrderEngine(root.Left);
                InOrderEngine(root.Right);
                Infix.Add(root.Value);
            }
        }
        public static void PreOrderEngine(INode root)
        {
            if (root != null)
            {
                Infix.Add(root.Value);
                InOrderEngine(root.Left);
                InOrderEngine(root.Right);
            }
        }
    }
}
