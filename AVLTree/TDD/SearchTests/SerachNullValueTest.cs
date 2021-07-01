using NUnit.Framework;
using AVLTree.Implementations;
using AVLTree.Interfaces;
using FluentAssertions;

namespace TDD
{
    public class SearchNullValueTest
    {  
        [Test]
        public void SearchNullValueSimpleTest()
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
            tree.Search(tree, 100).Should().BeNull();
        }
    }
}