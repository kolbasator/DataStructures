using NUnit.Framework;
using FluentAssertions;
using BinarySearchTree.BinarySearchTree.DataAccess.Implementations;

namespace TDD
{
    public class InsertFirstTest
    {  
        [Test]
        public void InsertFirstSimpleTest()
        {
            var tree = new BinarySearchTreeClass();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);
            tree.InOrderTraverse().Should().Be("20 30 40 50 60 70 80");
        }
    }
}