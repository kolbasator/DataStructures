using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.AddVertexTests
{
    public class AddVertexThirdTest
    { 
        [Test]
        public void AddVertexThirdSimpleTest()
        {
            var graph = new Graph<string>(4);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            (graph.GetVertices().FirstOrDefault(v => v.GetData() == "A") != null).Should().Be(true);
            (graph.GetVertices().FirstOrDefault(v => v.GetData() == "B") != null).Should().Be(true);
            (graph.GetVertices().FirstOrDefault(v => v.GetData() == "C") != null).Should().Be(true);
        }
    }
}