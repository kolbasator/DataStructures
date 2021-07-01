using System;  

namespace AVLTree.Interfaces
{
    public interface INode
    {
        int Key { get; set; }
        INode Left { get; set; }
        INode Right { get; set; } 
        INode Root { get; set; }
        int Height { get; set; }
        bool HasLeftChild { get;}
        bool HasRightChild { get; }
        bool HasNoChild { get; }
        int BalanceFactor(INode node);
        int GetHeight(INode node);
        void FixHeight(INode node);
        INode RotateRight(INode node);
        INode RotateLeft(INode node);
        INode HeavyLeftRotate(INode node);
        INode HeavyRightRotate(INode node);
        INode Balance(INode node);
        INode Search(INode node,int key);
        INode GetMin(INode node);
        INode GetMax(INode node);
        INode Insert(INode node, int key);
        INode Remove(INode node, int key);
        INode GetParent(int key); 
        string InOrderTraverse(INode node);
        string PostOrderTraverse(INode node);
        string PreOrderTraverse(INode node);

    }
}
