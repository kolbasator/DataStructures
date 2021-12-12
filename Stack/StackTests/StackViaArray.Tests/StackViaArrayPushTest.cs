using System;
using Stack.Interfaces;
using Stack.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace StackTests
{
    public class StackViaArrayPushTest
    {
        [Test]
        public void Push_Test()
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
            stack.IsFull.Should().BeTrue();
            stack.IsEmpty.Should().BeFalse();
            stack.Count.Should().Be(5);
            Action act = () => stack.Push('K');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Stack overflow");
        }

    }
}