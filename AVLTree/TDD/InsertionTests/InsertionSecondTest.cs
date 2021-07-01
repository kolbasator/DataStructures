using NUnit.Framework;
using AVLTree.Implementations;
using AVLTree.Interfaces;
using FluentAssertions;

namespace TDD
{
    public class InsertionSecondTest
    {
        [Test]
        public void InsertionSecondSimpleTest()
        {
            INode tree = new Node(20);
            tree = tree.Insert(tree, 30);
            tree = tree.Insert(tree, 40);
            tree = tree.Insert(tree, 60);
            tree = tree.Insert(tree, 90); 
            tree = tree.Insert(tree, 80);
            tree = tree.Insert(tree, 100);
            tree = tree.Insert(tree, 110); 
            tree.PreOrderTraverse(tree).Should().Be("60 30 20 40 90 80 100 110");
        }
    }
}