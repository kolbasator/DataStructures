using NUnit.Framework;
using BinaryHeap;
using FluentAssertions;
using System;
using System.Collections.Generic;

namespace TDD
{
    public class ExtractMaxSimpleTest
    {  
        [Test]
        public void ExtractMaxTest()
        {   
            var heap = new BinaryMaxHeap(new int[] { 4,1,3,2,16,9,10,14,8,7 });
            heap.ExtractMax().Should().Be(16);
            heap.ExtractMax().Should().Be(14);
            heap.ExtractMax().Should().Be(10);
            heap.ExtractMax().Should().Be(9);
            heap.ExtractMax().Should().Be(8);
            heap.ExtractMax().Should().Be(7);
            heap.ExtractMax().Should().Be(4);
            heap.ExtractMax().Should().Be(3);
            heap.ExtractMax().Should().Be(2);
            heap.ExtractMax().Should().Be(1);
            Action emptyHeapPop = () => heap.ExtractMax();
            emptyHeapPop.Should().Throw<Exception>()
                .WithMessage("Heap empty");
        }
    }
}