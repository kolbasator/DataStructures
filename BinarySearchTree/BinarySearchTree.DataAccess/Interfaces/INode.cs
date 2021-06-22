using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public interface INode
    {
        INode Left { get; set; }
        INode Right { get; set; }
        int Value { get; set; }
        bool HasRightChild { get;}
        bool HasLeftChild { get; } 
        bool HasNoChild { get; }
        void Delete(INode root, int key);
        INode Insert(int entity,INode tree);
        INode GetMax(INode tree);
        INode GetMin(INode tree);
        INode Search(int entity, INode tree);
        string InOrderTraverse();
        string PostOrderTraverse();
        string PreOrderTraverse();
    }
}
