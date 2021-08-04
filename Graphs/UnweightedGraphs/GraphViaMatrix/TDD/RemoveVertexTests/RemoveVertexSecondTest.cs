using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.RemoveVertexTests
{
    public class RemoveVertexSecondTest
    {
        [Test]
        public void RemoveVertexSecondSimpleTest()
        {
            var graph = new Graph<string>(6);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.RemoveVertex("B");
            graph.RemoveVertex("D"); 
            graph.GetSize().Should().Be(3);
            graph.GetVertices().Select(v => v.GetData()).Should().BeEquivalentTo("A", "C", "E");
        }
    }
}
