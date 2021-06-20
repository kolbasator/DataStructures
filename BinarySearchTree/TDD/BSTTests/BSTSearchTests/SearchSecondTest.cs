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
            var tree = new BinarySearchTreeClass();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);
            tree.Search(80).Value.Should().Be(80);
        }
    }
}