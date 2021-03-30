using NUnit.Framework;
using BinaryHeap;
using FluentAssertions;
using System.Collections.Generic;

namespace TDD
{
    public class GetMaxSimpleTest
    {  
        [Test]
        public void GetMaxTest()
        {   
            var heap = new BinaryMaxHeap(new int[] { 4,1,3,2,16,9,10,14,8,7 });
            heap.GetMax().Should().Be(16);
        }
    }
}