using NUnit.Framework;
using BinaryMinHeap;
using System;
using FluentAssertions;

namespace TDD
{
    public class PushSimpleTest
    {
        [Test]
        public void ExtractMinTest()
        {
            var heap = new BinaryMinHeapClass(new int[] { 45 });
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(5);
            heap.Items.Should().BeEquivalentTo(new int[] { 5,15,10,45 }); 
        }
    }
}