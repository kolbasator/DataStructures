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
            heap = new BinaryMinHeapClass(new int[] { 5,4,3,2,1 });
            heap.Items.ToArray().Should().BeEquivalentTo(new int[] { 1,2,3,5,4});
            heap = new BinaryMinHeapClass(new int[] { 8,9,9,3,5,6,20,10,12,18 });
            heap.Items.ToArray().Should().BeEquivalentTo(new int[] { 3, 5, 9, 6, 8, 20, 10, 12, 18, 9 }); 
        }
    }
}