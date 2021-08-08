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
            var graph = new Graph<string>(15);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddEdge("A","B",11);
            graph.AddEdge("A","C",21);
            graph.AddEdge("C","B",16);
            graph.AddEdge("D","C",14);
            graph.AddEdge("B","D",16);
            graph.AddEdge("E","F",18);
            graph.AddEdge("F","G",43);
            graph.AddEdge("E","C",56);
            graph.AddEdge("D","G",29);
            graph.GetNeighbours("A").Select(v=>v.GetData()).Should().BeEquivalentTo("B","C"); 
            graph.GetNeighbours("F").Select(v=>v.GetData()).Should().BeEquivalentTo("E","G"); 
            graph.GetNeighbours("C").Select(v=>v.GetData()).Should().BeEquivalentTo("A","B", "D", "E"); 
        }
    }
}
