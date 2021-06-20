using NUnit.Framework;
using LinkedList;
using FluentAssertions;

namespace TDD
{
    public class ContainsTest
    { 
        [Test]
        public void Test1()
        {
            var linkedList = new LinkedListClass<string>();
            linkedList.AddLast("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            linkedList.AddLast("D");
            linkedList.AddLast("E");
            linkedList.Contains("A").Should().BeTrue();
            linkedList.Contains("B").Should().BeTrue();
            linkedList.Contains("C").Should().BeTrue();
            linkedList.Contains("D").Should().BeTrue();
            linkedList.Contains("E").Should().BeTrue();  
            linkedList.Contains("F").Should().BeFalse();
            linkedList.Contains("G").Should().BeFalse();
            linkedList.Contains("H").Should().BeFalse(); 
        }
    }
}