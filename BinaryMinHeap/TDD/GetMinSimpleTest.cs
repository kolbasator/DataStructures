using NUnit.Framework;
using BinaryMinHeap;
using System;
using FluentAssertions;

namespace TDD
{
    public class GetMinSimpleTest
    {
        [Test]
        public void GetMinTest()
        {
            var heap = new BinaryMinHeapClass(new int[] { 45,15,10,5 });
            heap.GetMin().Should().Be(5);
        }
    }
}