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
            var graph = new Graph<string>();
            var a=graph.AddVertex("A");
            var b=graph.AddVertex("B");
            var c=graph.AddVertex("C");
            var d=graph.AddVertex("D");
            graph.AddVertex("E"); 
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("C", "B");
            graph.AddEdge("C", "A");
            graph.AddEdge("C", "D");
            graph.RemoveEdge(a, b);
            graph.RemoveEdge(a, d);
            graph.RemoveEdge(c, b);
            graph.RemoveEdge(c, a);
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
            graph.AreAdjacent("C", "A").Should().BeFalse();
            graph.AreAdjacent("C", "D").Should().BeTrue();
        }
    }
}