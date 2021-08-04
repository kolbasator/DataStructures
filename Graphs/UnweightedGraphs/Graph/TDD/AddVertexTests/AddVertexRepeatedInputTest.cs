using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System;

namespace TDD.AddVertexTests
{
    public class AddVertexRepeatedInputTest
    { 
        [Test]
        public void AddVertexRepeatedInputSimpleTest()
        {
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            Action act=()=>graph.AddVertex("A");
            act.Should().Throw<Exception>().WithMessage("Vertex has already been added.");
        }
    }
}