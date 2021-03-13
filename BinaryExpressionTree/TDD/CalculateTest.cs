using NUnit.Framework;
using BinaryExpressionTree;
using FluentAssertions;

namespace TDD
{
    public class CalculateTest
    { 
        [Test]
        public void TCalculateSimpleTest()
        {
            var tree = new BinaryExpressionTreeClass("2 * 2 + 2");
            var result = tree.Calculate();
            result.Should().Be(6);
            var tree2 = new BinaryExpressionTreeClass("2.5 * 9 + 8 ^ ( 7 - 6 )");
            var result2 = tree2.Calculate();
            result2.Should().Be(30.5); 
        }
    }
}