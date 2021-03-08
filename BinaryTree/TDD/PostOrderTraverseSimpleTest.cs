using NUnit.Framework;
using FluentAssertions;
using BinaryTree;

namespace TDD
{
    public class PostOrderTraverseTest
    { 
        [Test]
        public void PostOrderTest()
        {
            var root = new Node("1");
            var left = new Node("2"); 
            var right = new Node("3");
            left.Left = new Node("4");
            left.Right = new Node("5");
            root.Left = left;
            root.Right = right;
            var tree = new BinaryTreeClass(root);
            tree.PostOrder(tree.Root); 
            tree.Postfix.Should().Be("45231");

        }
    }
}