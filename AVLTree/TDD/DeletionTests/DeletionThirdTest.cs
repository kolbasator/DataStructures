using NUnit.Framework;
using AVLTree.Implementations;
using AVLTree.Interfaces;
using FluentAssertions;

namespace TDD
{
    public class DeletionThirdTest
    {
        [Test]
        public void DeletionThirdSimpleTest()
        {
            INode tree = new Node(2);
            tree = tree.Insert(tree, 1);
            tree = tree.Insert(tree, 5);
            tree = tree.Insert(tree, 4);
            tree = tree.Remove(tree,5);
            tree.PreOrderTraverse(tree).Should().Be("2 1 4");
        }
    }
}