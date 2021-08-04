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
            var graph = new Graph<string>();
            var first=graph.AddVertex("A"); 
            var second = graph.AddVertex("E");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddEdge("A", "B",8);
            graph.AddEdge("A", "D",9);
            graph.AddEdge("C", "B",7);
            Action firstAct = () => graph.RemoveEdge(null, null);
            Action secondAct = () => graph.RemoveEdge(first, second);
            firstAct.Should().Throw<Exception>().WithMessage("One or both vertices do not exist.");
            secondAct.Should().Throw<Exception>().WithMessage("Vertices are not connected.");
        }
    }
}
