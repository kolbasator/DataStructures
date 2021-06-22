using NUnit.Framework;
using FluentAssertions;
using BinarySearchTree.BinarySearchTree.DataAccess.Implementations;

namespace TDD
{
    public class SearchNullValueTest
    {  
        [Test]
        public void SearchNullValueSimpleTest()
        {
            var tree = new Node(50); 
            tree.Insert(30, tree);
            tree.Insert(20, tree);
            tree.Insert(40, tree);
            tree.Insert(70, tree);
            tree.Insert(60, tree);
            tree.Insert(80, tree);
            tree.Search(301, tree).Should().Be(null);
        }
    }
}