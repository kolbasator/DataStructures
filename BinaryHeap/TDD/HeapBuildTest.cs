using NUnit.Framework;
using BinaryHeap;
using FluentAssertions;
using System.Collections.Generic;

namespace TDD
{
    public class HeapBuildSimpleTest
    {  
        [Test]
        public void HeapBuildTest()
        {   
            var heap = new BinaryMaxHeap(new int[] { 4,1,3,2,16,9,10,14,8,7 });
            heap.Items.ToArray().Should().BeEquivalentTo(new int[] {16,14,10,8,7,9,3,2,4,1});
        }
    }
}