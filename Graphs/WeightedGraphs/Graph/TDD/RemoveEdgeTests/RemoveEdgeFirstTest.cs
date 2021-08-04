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
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            var edge=graph.AddEdge("A", "B",8);
            graph.RemoveEdge(edge);
            graph.AreAdjacent("A", "B").Should().BeFalse();
        }
    }
}
