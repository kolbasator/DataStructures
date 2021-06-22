using NUnit.Framework;
using FluentAssertions;
using BinarySearchTree.BinarySearchTree.DataAccess.Implementations;

namespace TDD
{
    public class SearchSecondTest
    {  
        [Test]
        public void SearchSecondSimpleTest()
        {
            var tree = new Node(50);
            tree.Insert(50, tree);
            tree.Insert(30, tree);
            tree.Insert(20, tree);
            tree.Insert(40, tree);
            tree.Insert(70, tree);
            tree.Insert(60, tree);
            tree.Insert(80, tree);
            tree.Search(80, tree).Value.Should().Be(80);
        }
    }
}