using System;
using Stack.Interfaces;
using Stack.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace StackTests
{
    public class StackPopTest
    {
        [Test]
        public void Pop_Test()
        {
            IStack<char> stack = new Stack<char>(); 
            stack.Push('A'); 
            stack.Push('B'); 
            stack.Push('C'); 
            stack.Push('D'); 
            stack.Push('E');
            stack.Count.Should().Be(5); 
            stack.Pop().Should().Be('E');
            stack.Count.Should().Be(4);
            stack.Pop().Should().Be('D');
            stack.Count.Should().Be(3);
            stack.Pop().Should().Be('C');
            stack.Count.Should().Be(2);
            stack.Pop().Should().Be('B');
            stack.Count.Should().Be(1);
            stack.Pop().Should().Be('A');
            stack.Count.Should().Be(0);

            Action act = () => stack.Pop();
            act.Should().Throw<IndexOutOfRangeException>()
                .WithMessage("Stack is empty.");
        }

    }
}