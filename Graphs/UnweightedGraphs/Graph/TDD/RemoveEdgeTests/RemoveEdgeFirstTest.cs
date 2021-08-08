using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.RemoveEdgeTests
{
    public class RemoveEdgeFirstTest
    {
        [Test]
        public void RemoveEdgeFirstSimpleTest()
        {
            var graph = new Graph<string>();
            var a=graph.AddVertex("A");
            var b=graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddEdge("A", "B");
            graph.RemoveEdge(a, b);
            graph.AreAdjacent("A", "B").Should().BeFalse();
        }
    }
}
