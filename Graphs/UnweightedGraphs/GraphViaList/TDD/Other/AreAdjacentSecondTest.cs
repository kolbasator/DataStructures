using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.Other
{
    public class AreAdjacentSecondTest
    {
        [Test]
        public void AreAdjacentSEcondSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H"); 
            graph.AddEdge("E", "F");
            graph.AddEdge("H", "G");
            graph.AddEdge("G", "E"); 
            graph.AreAdjacent("E", "F").Should().BeTrue();
            graph.AreAdjacent("H", "G").Should().BeTrue();
            graph.AreAdjacent("G", "E").Should().BeTrue(); 
            graph.AreAdjacent("F", "F").Should().BeFalse();
            graph.AreAdjacent("H", "E").Should().BeFalse();
            graph.AreAdjacent("F", "G").Should().BeFalse();
        }
    }
}
