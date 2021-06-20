using NUnit.Framework;
using LinkedList;
using FluentAssertions;

namespace TDD
{
    public class FindTest
    { 
        [Test]
        public void FindSimpleTest()
        {
            var linkedList = new LinkedListClass<string>();
            linkedList.AddLast("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            var firstItem = linkedList.Find("A");
            var secondItem = linkedList.Find("B");
            var thirdItem = linkedList.Find("C");
            firstItem.Data.Should().Be("A");
            secondItem.Data.Should().Be("B");
            thirdItem.Data.Should().Be("C");
            var fourthItem = linkedList.Find("X");
            fourthItem.Should().Be(null); 
        }
    }
}