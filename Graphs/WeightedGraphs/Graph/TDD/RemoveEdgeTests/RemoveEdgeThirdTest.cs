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
            var first=graph.AddEdge("A", "B",9);
            var second=graph.AddEdge("A", "D",8);
            var third=graph.AddEdge("C", "B",4);
            var fours=graph.AddEdge("C", "A",7); 
            graph.RemoveEdge(first);
            graph.RemoveEdge(second);
            graph.RemoveEdge(third);
            graph.RemoveEdge(fours);
            graph.AreAdjacent("A", "B").Should().BeFalse();
            graph.AreAdjacent("A", "D").Should().BeFalse();
            graph.AreAdjacent("C", "B").Should().BeFalse();
            graph.AreAdjacent("C", "A").Should().BeFalse(); 
        }
    }
}