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
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddEdge("A", "B",7);
            graph.AddEdge("B", "C",9);
            graph.AreAdjacent("A", "B").Should().BeTrue();
            graph.AreAdjacent("B", "C").Should().BeTrue();
        }
    }
}