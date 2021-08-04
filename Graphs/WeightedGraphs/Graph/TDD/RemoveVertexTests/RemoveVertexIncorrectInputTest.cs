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
            var graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddEdge("A", "B",6);
            graph.AddEdge("A", "D",6);
            graph.AddEdge("C", "B",8);
            graph.AddEdge("A", "C",5);
            graph.AddEdge("C", "D",3);
            graph.AddEdge("F", "G",7);
            graph.AddEdge("E", "F",3);
            graph.AddEdge("E", "D",4); 
            Action secondAct = () => graph.RemoveVertex("M"); 
            secondAct.Should().Throw<Exception>().WithMessage("The vertex does not exist.");
        }
    }
}
