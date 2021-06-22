using NUnit.Framework;
using FluentAssertions;
using BinarySearchTree.BinarySearchTree.DataAccess.Implementations;

namespace TDD
{
    public class InsertThirdTest
    {
        [Test]
        public void InsertThirdSimpleTest()
        {
            var tree = new Node(15);
            tree.Insert(10, tree);
            tree.Insert(20, tree);
            tree.Insert(8, tree);
            tree.Insert(12, tree);
            tree.Insert(25, tree);
            tree.InOrderTraverse().Should().Be("8 10 12 15 20 25");
        }
    }
}