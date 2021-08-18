using System.Linq;
using Graph.DataAccess.Interfaces;
using Graph.DataAccess.Models;
using System.Collections.Generic;

namespace Graph.DataAccess.Algorithms
{
    public class DijkstraAlgorithm<T>
    { 
        public List<DistanceModel<T>> Dijkstra(IGraph<T> graph, IVertex<T> start)
        {
            foreach (var vertex in graph.GetVertices())
                vertex.UnVisit();
            var list = new List<DistanceModel<T>> { new DistanceModel<T>(start, 0, start)}; 
            var current = start; 
            while (graph.UnVisitedVertices().Any())
            {
                current.Visit(); 
                foreach (var neighbour in current.GetUnvisitedNeighbours())
                { 
                    var tentativeDist = neighbour.GetWeight() + GetModel(list, current).Distance();
                    if (ContainsAndGreater(list, neighbour.GetNeighbour(), tentativeDist))
                    {
                        var neighbourModel = GetModel(list, neighbour.GetNeighbour());
                        neighbourModel.ChangeDistance(tentativeDist);
                        neighbourModel.ChangePrevios(current);
                    }
                    else if(!Contains(list,neighbour.GetNeighbour()))
                    {
                        list.Add(new DistanceModel<T>(neighbour.GetNeighbour(), tentativeDist, current));
                    }
                }
                current = MinUnvisitedVertex(list);
            } 
            return list;

        }
        private IVertex<T> MinUnvisitedVertex(List<DistanceModel<T>> list)
        {
            var newList = list.OrderBy(m => m.Distance());
            IVertex<T> result = null;
            foreach(var m in newList)
            {
                if (!m.Current().IsVisited())
                {
                    result = m.Current();
                    break;
                }
            }
            return result;
        } 
        private DistanceModel<T> GetModel(List<DistanceModel<T>> list, IVertex<T> vertex)
        {
            return list.First(m => m.Current().Equals(vertex));
        }
        private bool Contains(List<DistanceModel<T>> list, IVertex<T> vertex)
        {
            return list.Any(m => m.Current().Equals(vertex));
        }
        private bool ContainsAndGreater(List<DistanceModel<T>> list, IVertex<T> vertex, int tentativeDistance)
        {
            return list.Any(m => m.Current().Equals(vertex) && tentativeDistance < m.Distance());
        }
    }
}
