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
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            var first=graph.AddEdge("A", "B",2);
            var second=graph.AddEdge("A", "D",3);
            var third=graph.AddEdge("C", "B",8);
            graph.RemoveEdge(first);
            graph.RemoveEdge(second);
            graph.RemoveEdge(third);
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
        }
    }
}
