using NUnit.Framework;
using AVLTree.Implementations;
using AVLTree.Interfaces;
using FluentAssertions;

namespace TDD
{
    public class SearchFirstTest
    {  
        [Test]
        public void SearchFirstSimpleTest()
        {
            INode tree = new Node(1);
            tree = tree.Insert(tree, 2);
            tree = tree.Insert(tree, 3);
            tree = tree.Insert(tree, 4);
            tree = tree.Insert(tree, 5);
            tree = tree.Insert(tree, 6);
            tree = tree.Insert(tree, 7);
            tree = tree.Insert(tree, 8);
            tree = tree.Insert(tree, 9);
            tree.Search(tree, 2).Key.Should().Be(2);
        }
    }
}