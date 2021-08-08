using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System;

namespace TDD.Other
{
    public class AreAdjacentIncorrectInputTest
    {
        [Test]
        public void AreAdjacentIncorrectInputSimpleTest()
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
            graph.AddEdge("A", "C");
            graph.AddEdge("A", "D");
            graph.AddEdge("A", "E");
            graph.AddEdge("A", "F");
            graph.AddEdge("A", "G");
            graph.AddEdge("B", "D");
            graph.AddEdge("C", "D");
            graph.AddEdge("B", "C");
            graph.AddEdge("E", "F"); 
            Action secondAct = () => graph.AreAdjacent("Musyaka", "Brain"); 
            secondAct.Should().Throw<Exception>().WithMessage("One or both vertices do not exist.");
        }
    }
}
