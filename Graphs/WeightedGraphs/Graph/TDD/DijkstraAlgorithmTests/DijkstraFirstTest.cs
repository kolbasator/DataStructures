using NUnit.Framework;
using Graph.DataAccess.Implementations;
using FluentAssertions;
using System.Linq;

namespace TDD.DijkstraAlgorithmTests
{
    public class DijkstraFirstTest
    {
        [Test]
        public void DijkstraFirstSimpleTest()
        {
            var graph = new Graph<string>();
            var start=graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");
            graph.AddVertex("J");
            var end = graph.AddVertex("I"); 
            graph.AddEdge("A", "B", 5);
            graph.AddEdge("A", "C", 7);
            graph.AddEdge("C", "D", 1);
            graph.AddEdge("B", "D", 4);
            graph.AddEdge("B", "E", 8);
            graph.AddEdge("D", "G", 10);
            graph.AddEdge("C", "F", 9);
            graph.AddEdge("E", "G", 13);
            graph.AddEdge("F", "H", 11);
            graph.AddEdge("H", "G", 10);
            graph.AddEdge("H", "J",3);
            graph.AddEdge("J", "I", 7);
            graph.AddEdge("G", "I", 18);
            var dijkstra = new DijkstraAlgorithm<string>(graph);
            dijkstra.Dijkstra(start, end).Select(v => v.GetData()).Should().BeEquivalentTo("A", "C", "D", "G", "I");
        }
    }
}
