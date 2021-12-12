using Stack.Interfaces;
using Stack.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace StackTests
{
    public class StackPeekTest
    {
        [Test]
        public void Peek_Test()
        {
            IStack<char> stack = new Stack<char>(); 
            stack.Push('A'); 
            stack.Push('B'); 
            stack.Push('C'); 
            stack.Push('D'); 
            stack.Push('E'); 
            stack.IsEmpty.Should().BeFalse();
            stack.Count.Should().Be(5);
            stack.Peek().Should().Be('E');
            stack.Peek().Should().Be('E');
            stack.Peek().Should().Be('E');
        }

    }
}