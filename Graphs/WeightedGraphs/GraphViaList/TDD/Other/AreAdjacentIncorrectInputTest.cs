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
            graph.AddEdge("A", "B",1);
            graph.AddEdge("A", "C",2);
            graph.AddEdge("A", "D",1);
            graph.AddEdge("A", "E",3);
            graph.AddEdge("A", "F",3);
            graph.AddEdge("A", "G",8);
            graph.AddEdge("B", "D",9);
            graph.AddEdge("C", "D",6);
            graph.AddEdge("B", "C",9);
            graph.AddEdge("E", "F",11); 
            Action secondAct = () => graph.AreAdjacent("Musyaka", "Brain"); 
            secondAct.Should().Throw<Exception>().WithMessage("One or both vertices do not exist.");
        }
    }
}
