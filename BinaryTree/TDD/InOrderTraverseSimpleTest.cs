using NUnit.Framework;
using FluentAssertions;
using BinaryTree;

namespace TDD
{
    public class InOrderTraverseTest
    { 
        [Test]
        public void InOrderTest()
        {
            var root = new Node("1");
            var left = new Node("2"); 
            var right = new Node("3");
            left.Left = new Node("4");
            left.Right = new Node("5");
            root.Left = left;
            root.Right = right;
            var tree = new BinaryTreeClass(root);
            tree.InOrder(tree.Root); 
            tree.Infix.Should().Be("42513");

        }
    }
}