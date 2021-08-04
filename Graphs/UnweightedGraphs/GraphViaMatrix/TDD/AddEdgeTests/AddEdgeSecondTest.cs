using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.AddEdgeTests
{
    public class AddEdgeSecondTest
    { 
        [Test]
        public void AddEdgeSecondSimpleTest()
        {
            var graph = new Graph<string>(4);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AreAdjacent("A", "B").Should().BeTrue();
            graph.AreAdjacent("B", "C").Should().BeTrue();
        }
    }
}