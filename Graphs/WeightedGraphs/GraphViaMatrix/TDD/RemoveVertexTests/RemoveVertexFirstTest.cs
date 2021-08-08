using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.RemoveVertexTests
{
    public class RemoveVertexFirstTest
    {
        [Test]
        public void RemoveVertexFirstSimpleTest()
        {
            var graph = new Graph<string>(15);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.RemoveVertex("C");
            graph.GetSize().Should().Be(2);
            graph.GetVertices().Select(v => v.GetData()).Should().BeEquivalentTo("A", "B");
        }
    }
}
