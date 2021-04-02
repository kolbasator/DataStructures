using NUnit.Framework;
using BinaryMinHeap;
using FluentAssertions;
namespace TDD
{
    public class MinHeapBuildSimpleTest
    {  
        [Test]
        public void BinaryMinHeapBuildTest()
        {
            var heap = new BinaryMinHeapClass(new int[] { 45,15,10,5 });
            heap.Items.ToArray().Should().BeEquivalentTo(new int[] { 5,15,10,45 });
        }
    }
}