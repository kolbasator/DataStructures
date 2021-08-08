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
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E"); 
            graph.AddEdge("A", "B",9);
            graph.AddEdge("A", "D",8);
            graph.AddEdge("C", "B",4);
            graph.AddEdge("C", "A",7); 
            graph.RemoveEdge("A", "B");
            graph.RemoveEdge("A", "D");
            graph.RemoveEdge("C", "B");
            graph.RemoveEdge("C", "A");
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
            graph.AreAdjacent("C", "A").Should().BeFalse(); 
        }
    }
}