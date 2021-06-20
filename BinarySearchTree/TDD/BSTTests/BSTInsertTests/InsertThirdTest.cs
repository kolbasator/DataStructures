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
            var tree = new BinarySearchTreeClass(); 
            tree.Insert(15);
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(8);
            tree.Insert(12);
            tree.Insert(25); 
            tree.InOrderTraverse().Should().Be("8 10 12 15 20 25");
        }
    }
}