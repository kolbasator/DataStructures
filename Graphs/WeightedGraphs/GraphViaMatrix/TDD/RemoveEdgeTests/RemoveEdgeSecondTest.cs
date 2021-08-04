using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.RemoveEdgeTests
{
    public class RemoveEdgeSecondTest
    {
        [Test]
        public void RemoveEdgeSecondSimpleTest()
        {
            var graph = new Graph<string>(6);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("C", "B");
            graph.RemoveEdge("A", "B");
            graph.RemoveEdge("A", "D");
            graph.RemoveEdge("C", "B");
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
        }
    }
}
