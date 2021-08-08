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
            var a=graph.AddVertex("A");
            var b=graph.AddVertex("B");
            var c=graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge("A", "B"); 
            graph.AddEdge("C", "B");
            graph.RemoveEdge(a, b); 
            graph.RemoveEdge(c, b);
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
        }
    }
}
