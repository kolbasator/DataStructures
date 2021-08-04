using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.RemoveVertexTests
{
    public class RemoveVertexThirdTest
    {
        [Test]
        public void RemoveVertexThirdSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddEdge("A", "B",6);
            graph.AddEdge("A", "D",56);
            graph.AddEdge("C", "B",76);
            graph.AddEdge("A", "C",45);
            graph.AddEdge("C", "D",76);
            graph.AddEdge("F", "G",34);
            graph.AddEdge("E", "F",64);
            graph.AddEdge("E", "D",86);
            graph.RemoveVertex("B");
            graph.RemoveVertex("D"); 
            graph.RemoveVertex("F"); 
            graph.RemoveVertex("G"); 
            graph.GetSize().Should().Be(3);
            graph.GetVertices().Select(v => v.GetData()).Should().BeEquivalentTo("A", "C", "E");
            graph.GetVertices().Select(v => v.GetData()).Should().BeEquivalentTo("A", "C", "E");
        }
    }
}
