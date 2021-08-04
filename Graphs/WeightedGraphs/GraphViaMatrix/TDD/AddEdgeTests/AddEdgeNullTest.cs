using System;
using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;

namespace TDD.AddEdgeTests
{
    public class AddEdgeNullTest
    {
        [Test]
        public void AddEdgeNullSimpleTest()
        {
            var graph = new Graph<string>(3);
            graph.AddVertex("A");
            graph.AddVertex("B");
            Action act = () => graph.AddVertex(null);
            act.Should().Throw<Exception>().WithMessage("Incorrect input.");
        }
    }
}