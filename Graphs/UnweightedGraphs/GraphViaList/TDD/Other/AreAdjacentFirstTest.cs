using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.Other
{
    public class AreAdjacentFirstTest
    {
        [Test]
        public void AreAdjacentFirstSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("E", "D");
            graph.AddEdge("A", "E");
            graph.AreAdjacent("A", "B").Should().BeTrue();
            graph.AreAdjacent("A", "C").Should().BeTrue();
            graph.AreAdjacent("E", "D").Should().BeTrue();
            graph.AreAdjacent("A", "E").Should().BeTrue();
            graph.AreAdjacent("A", "D").Should().BeFalse();
        }
    }
}
