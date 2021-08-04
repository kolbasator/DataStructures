using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.RemoveEdgeTests
{
    public class RemoveEdgeThirdTest
    {
        [Test]
        public void RemoveEdgeThirdSimpleTest()
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
            graph.AddEdge("C", "A");
            graph.AddEdge("C", "D");
            graph.RemoveEdge("A", "B");
            graph.RemoveEdge("A", "D");
            graph.RemoveEdge("C", "B");
            graph.RemoveEdge("C", "A");
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
            graph.AreAdjacent("C", "A").Should().BeFalse();
            graph.AreAdjacent("C", "D").Should().BeTrue();
        }
    }
}