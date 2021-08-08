using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.AddEdgeTests
{
    public class AddEdgeFirstTest
    { 
        [Test]
        public void AddEdgeFirstSimpleTest()
        { 
            var graph = new Graph<string>(15); 
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddEdge("A", "B",8);
            graph.AreAdjacent("A", "B").Should().BeTrue();
        }
    }
}