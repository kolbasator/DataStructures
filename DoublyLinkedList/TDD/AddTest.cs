using NUnit.Framework;
using LinkedList;
using FluentAssertions;

namespace TDD
{
    public class AddTest
    { 
        [Test]
        public void AddSimpleTest()
        {
            var linkedList = new LinkedListClass<string>();
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.Count.Should().Be(0);
            linkedList.AddFirst("B");
            linkedList.AddFirst("A");
            linkedList.AddLast("C");
            linkedList.AddLast("D");
            linkedList.AddLast("E");
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Count.Should().Be(5);
            linkedList.First.Data.Should().Be("A");
            linkedList.First.Next.Data.Should().Be("B");
            linkedList.First.Next.Next.Data.Should().Be("C");
            linkedList.First.Next.Next.Next.Data.Should().Be("D");
            linkedList.First.Next.Previous.Data.Should().Be("A");
            linkedList.First.Next.Next.Previous.Data.Should().Be("B");
            linkedList.First.Next.Next.Next.Previous.Data.Should().Be("C");
            linkedList.Last.Data.Should().Be("E");
            linkedList.Last.Previous.Data.Should().Be("D");
            linkedList.Clear();
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.Count.Should().Be(0);
        }
    }
}