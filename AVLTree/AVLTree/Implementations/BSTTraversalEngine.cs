using System.Collections.Generic; 

namespace AVLTree.Interfaces
{
    public static class BSTTraversalEngine
    {
        public static List<int> Infix = new List<int>();
        public static List<int> Postfix = new List<int>();
        public static List<int> Prefix = new List<int>();
        public static void InOrderEngine(INode node)
        {
            if (node != null)
            {
                InOrderEngine(node.Left);
                Infix.Add(node.Key);
                InOrderEngine(node.Right);
            }
        }
        public static void PostOrderEngine(INode node)
        {
            if (node != null)
            {
                InOrderEngine(node.Left);
                InOrderEngine(node.Right);
                Infix.Add(node.Key);
            }
        }
        public static void PreOrderEngine(INode node)
        {
            if (node != null)
            {
                Infix.Add(node.Key);
                InOrderEngine(node.Left);
                InOrderEngine(node.Right);
            }
        }
    }
}
