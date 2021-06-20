using NUnit.Framework;
using LinkedList;
using FluentAssertions;

namespace TDD
{
    public class RemoveTest
    { 
        [Test]
        public void RemoveSimpleTest()
        {
            var linkedList = new LinkedListClass<string>();
            linkedList.AddLast("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            linkedList.AddLast("D");
            linkedList.AddLast("E");
            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.First.Data.Should().Be("B");
            linkedList.Last.Data.Should().Be("D"); 
            linkedList.RemoveLast();
            linkedList.RemoveLast();
            linkedList.Count.Should().Be(1);
            linkedList.First.Data.Should().Be("B");
        }
    }
}