using NUnit.Framework;
using FluentAssertions;
using BinarySearchTree.BinarySearchTree.DataAccess.Implementations;

namespace TDD
{
    public class DeleteSecondTest
    {  
        [Test]
        public void DeleteSecondSimpleTest()
        {
            var tree = new BinarySearchTreeClass();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);
            tree.Delete(tree.Root,30);
            tree.Delete(tree.Root,40);
            tree.Delete(tree.Root,50); 
            tree.InOrderTraverse().Should().Be("20 60 70 80");
        }
    }
}