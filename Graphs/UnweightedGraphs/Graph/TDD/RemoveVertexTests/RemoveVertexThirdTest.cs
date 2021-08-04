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
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("C", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("C", "D");
            graph.AddEdge("F", "G");
            graph.AddEdge("E", "F");
            graph.AddEdge("E", "D");
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
