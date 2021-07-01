using NUnit.Framework;
using AVLTree.Implementations;
using AVLTree.Interfaces;
using FluentAssertions;

namespace TDD
{
    public class InsertionThirdTest
    {
        [Test]
        public void InsertionThirdSimpleTest()
        {
            INode tree = new Node(12);
            tree = tree.Insert(tree, 26);
            tree = tree.Insert(tree, 6);
            tree = tree.Insert(tree, 35);
            tree = tree.Insert(tree,48); 
            tree = tree.Insert(tree, 14);
            tree = tree.Insert(tree, 8);
            tree = tree.Insert(tree, 9); 
            tree = tree.Insert(tree, 1); 
            tree = tree.Insert(tree, 78); 
            tree = tree.Insert(tree, 92); 
            tree = tree.Insert(tree, 106); 
            tree = tree.Insert(tree, 13); 
            tree.PreOrderTraverse(tree).Should().Be("26 8 6 1 12 9 14 13 48 35 92 78 106");
        }
    }
}