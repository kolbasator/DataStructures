using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.Other
{
    public class GetNeighboursTest
    {
        [Test]
        public void GetNeighborsSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddEdge("A","B");
            graph.AddEdge("A","C");
            graph.AddEdge("C","B");
            graph.AddEdge("D","C");
            graph.AddEdge("B","D");
            graph.AddEdge("E","F");
            graph.AddEdge("F","G");
            graph.AddEdge("E","C");
            graph.AddEdge("D","G");
            graph.GetNeighbours("A").Select(v=>v.GetData()).Should().BeEquivalentTo("B","C"); 
            graph.GetNeighbours("F").Select(v=>v.GetData()).Should().BeEquivalentTo("E","G"); 
            graph.GetNeighbours("C").Select(v=>v.GetData()).Should().BeEquivalentTo("A","B", "D", "E"); 
        }
    }
}
