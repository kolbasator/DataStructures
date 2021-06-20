using NUnit.Framework;
using LinkedList;
using FluentAssertions;

namespace TDD
{
    public class ReverseTest
    { 
        [Test]
        public void ReverseSimpleTest()
        {
            var linkedList = new LinkedListClass<string>();
            linkedList.AddLast("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            linkedList.Reverse();
            linkedList.First.Data.Should().Be("C");
            linkedList.Last.Previous.Data.Should().Be("B");
            linkedList.Last.Data.Should().Be("A");
        }
    }
}