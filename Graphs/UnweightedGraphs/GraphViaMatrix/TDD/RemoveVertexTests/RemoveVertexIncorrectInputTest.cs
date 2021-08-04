using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System;

namespace TDD.RemoveVertexTests
{
    public class RemoveVertexIncorrectInputTest
    {
        [Test]
        public void RemoveVertexIncorrectInputSimpleTest()
        {
            var graph = new Graph<string>(8);
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
            Action firstAct = () => graph.RemoveVertex(null);
            Action secondAct = () => graph.RemoveVertex("M");
            firstAct.Should().Throw<Exception>().WithMessage("Incorrect input.");
            secondAct.Should().Throw<Exception>().WithMessage("The vertex does not exist.");
        }
    }
}
