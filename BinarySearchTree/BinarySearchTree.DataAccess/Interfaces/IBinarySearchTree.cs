using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public interface IBinarySearchTree
    {
        INode Root { get; set; }
        void Delete(INode root,int key);
        INode Insert(int entity);
        INode GetMax(INode current);
        INode GetMin(INode current);
        INode Search(int entity);
        string InOrderTraverse();
        string PostOrderTraverse();
        string PreOrderTraverse();
    }
}
