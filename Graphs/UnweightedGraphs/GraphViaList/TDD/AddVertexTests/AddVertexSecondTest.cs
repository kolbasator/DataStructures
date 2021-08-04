using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.AddVertexTests
{
    public class AddVertexSecondTest
    { 
        [Test]
        public void AddVertexSecondSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B"); 
            (graph.GetVertices().FirstOrDefault(v => v.GetData() == "B") != null).Should().Be(true);
        }
    }
}