using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.AddVertexTests
{
    public class AddVertexFirstTest
    { 
        [Test]
        public void AddVertexFirstSimpleTest()
        {
            var graph = new Graph<string>(2);
            graph.AddVertex("A");
            (graph.GetVertices().FirstOrDefault(v => v.GetData() == "A") != null).Should().Be(true);
        }
    }
}