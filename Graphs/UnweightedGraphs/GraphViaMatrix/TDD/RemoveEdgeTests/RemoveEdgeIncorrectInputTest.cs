using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System;

namespace TDD.RemoveEdgeTests
{
    public class RemoveEdgeIncorrectInputTest
    {
        [Test]
        public void RemoveEdgeIncorrectInputSimpleTest()
        {
            var graph = new Graph<string>(6);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("C", "B"); 
            Action secondAct = () => graph.RemoveEdge("A", "E"); 
            secondAct.Should().Throw<Exception>().WithMessage("Vertices are not connected.");
        }
    }
}
