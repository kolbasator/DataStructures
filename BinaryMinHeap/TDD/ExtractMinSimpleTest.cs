using NUnit.Framework;
using BinaryMinHeap;
using System;
using FluentAssertions;

namespace TDD
{
    public class ExtractMinSimpleTest
    {
        [Test]
        public void ExtractMinTest()
        {
            var heap = new BinaryMinHeapClass(new int[] { 45, 15, 10, 5 });
            var first = heap.ExtractMin();
            var second = heap.ExtractMin();
            var third = heap.ExtractMin();
            var fourth = heap.ExtractMin();
            Action fifth = () => heap.ExtractMin();
            first.Should().Be(5);
            second.Should().Be(10);
            third.Should().Be(15);
            fourth.Should().Be(45);
            fifth.Should().Throw<Exception>()
                .WithMessage("Heap empty");
        }
    }
}