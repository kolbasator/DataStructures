using System.Linq;
using Graph.DataAccess.Interfaces;
using System.Collections.Generic;

namespace Graph.DataAccess.Implementations
{
    public class DijkstraAlgorithm<T> : IDijkstraAlgorithm<T>
    {
        private IGraph<T> _currentGraph;
        public DijkstraAlgorithm(IGraph<T> graph)
        {
            _currentGraph = graph;
        }

        /// <summary>
        /// Returns shortest path from start vertex to end vertex.
        /// </summary> 
        public List<IVertex<T>> Dijkstra(IVertex<T> start, IVertex<T> end)
        {
            foreach (var vertex in _currentGraph.GetVertices())
            {
                vertex.UnVisit();
                vertex.SetDistance(int.MaxValue);
            }
            start.SetDistance(0);
            var current = start;
            while (_currentGraph.GetVertices().Where(v => v.IsVisited() == false).Count() > 0)
            {
                var neighbours = _currentGraph.GetNeighbours(current);
                foreach (var neighbour in neighbours)
                {
                    var edge=_currentGraph.GetEdges().Where(e => e.FirstVertex().Equals(current) && e.SecondVertex().Equals(neighbour) || e.FirstVertex().Equals(neighbour) && e.SecondVertex().Equals(current)).OrderBy(e => e.GetWeight()).FirstOrDefault();
                    neighbour.SetDistance(neighbour.GetDistance() < current.GetDistance() + edge.GetWeight() ? neighbour.GetDistance() : current.GetDistance() + edge.GetWeight());
                }
                current.Visit();
                current = _currentGraph.GetVertices().Where(v => v.IsVisited() == false).OrderBy(v => v.GetDistance()).FirstOrDefault();
            } 
            return RestorePath(start, end); 
        } 
        private List<IVertex<T>> RestorePath(IVertex<T> start, IVertex<T> end)
        {
            var current = end;
            var path = new List<IVertex<T>>();
            while (current != start)
            {
                foreach (var neighbour in _currentGraph.GetNeighbours(current))
                {
                    var edge = _currentGraph.GetEdges().Where(e => e.FirstVertex().Equals(current) && e.SecondVertex().Equals(neighbour) || e.FirstVertex().Equals(neighbour) && e.SecondVertex().Equals(current)).OrderBy(e => e.GetWeight()).FirstOrDefault();
                    if (current.GetDistance() - edge.GetWeight() == neighbour.GetDistance())
                    {
                        path.Add(current);
                        current = neighbour;
                        break;
                    }
                }
            }
            path.Add(start);
            path.Reverse();
            return path;
        }
    }
}
