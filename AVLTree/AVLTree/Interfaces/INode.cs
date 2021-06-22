using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public interface INode
    {
        int Key { get; set; }
        INode Left { get; set; }
        INode Right { get; set; } 
        INode Root { get; set; }
        int Height { get; set; }
        bool HasLeftChild { get; set; }
        bool HasRightChild { get; }
        bool HasNoChild { get; }
        int BalanceFactor(INode node);
        int GetHeight(INode node);
        void FixHeight(INode node);
        INode RotateRight(INode node);
        INode RotateLeft(INode node);
        INode RotateLeftRight(INode node);
        INode RotateRightLeft(INode node);
        INode Balance(INode node);
        INode Insert(INode node, int key);
        INode Remove(INode node, int key);
    }
}
