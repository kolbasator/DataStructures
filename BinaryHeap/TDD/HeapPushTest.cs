using NUnit.Framework;
using BinaryHeap;
using FluentAssertions;
using System;
using System.Collections.Generic;

namespace TDD
{
    public class HeapPushSimpleTest
    {
        [Test]
        public void HeapPushTest()
        {
            var heap = new BinaryMaxHeap(new int[] { 10 });
            heap.Insert(6);
            heap.Insert(7);
            heap.Insert(8);
            heap.Insert(9);
            heap.Items.ToArray().Should().BeEquivalentTo(new int[] { 10,9,8,6,7}); 
        }
    }
}