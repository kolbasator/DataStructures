using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.AddEdgeTests
{
    public class AddEdgeThirdTest
    { 
        [Test]
        public void AddEdgeThirdSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "D");
            graph.AreAdjacent("A", "B").Should().BeTrue();
            graph.AreAdjacent("B", "C").Should().BeTrue();
            graph.AreAdjacent("A", "D").Should().BeTrue();
        }
    }
}