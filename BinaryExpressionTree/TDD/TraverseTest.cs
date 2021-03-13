using NUnit.Framework;
using BinaryExpressionTree;
using FluentAssertions;

namespace TDD
{
    public class TraverseTest
    { 
        [Test]
        public void TraverseSimpleTest()
        {
            var tree = new BinaryExpressionTreeClass("2 * 2 + 2");
            var inOrderTraverse = tree.InOrderTraverse();
            inOrderTraverse.Should().Be("2 * 2 + 2");
            var postOrderTraverse = tree.PostOrderTraverse();
            postOrderTraverse.Should().Be("22*2+");
            var tree2 = new BinaryExpressionTreeClass("2.5 + 100 + (2*2)");
            var inOrderTraverse2 = tree2.InOrderTraverse();
            inOrderTraverse2.Should().Be("2.5 + 100 + 2 * 2");
            var postOrderTraverse2 = tree2.PostOrderTraverse();
            postOrderTraverse2.Should().Be("2.5100+22*+");

        }
    }
}