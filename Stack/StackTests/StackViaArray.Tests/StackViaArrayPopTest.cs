using System;
using Stack.Interfaces;
using Stack.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace StackTests
{
    public class StackViaArrayPopTest
    {
        [Test]
        public void Pop_Test()
        {
            IStackViaArray<char> stack = new StackViaArray<char>(5);
            stack.IsFull.Should().BeFalse();
            stack.Push('A');
            stack.IsFull.Should().BeFalse();
            stack.Push('B');
            stack.IsFull.Should().BeFalse();
            stack.Push('C');
            stack.IsFull.Should().BeFalse();
            stack.Push('D');
            stack.IsFull.Should().BeFalse();
            stack.Push('E');
            stack.Count.Should().Be(5);
            stack.IsFull.Should().BeTrue();
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