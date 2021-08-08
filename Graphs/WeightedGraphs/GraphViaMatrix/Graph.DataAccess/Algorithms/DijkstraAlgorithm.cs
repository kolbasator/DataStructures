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
            graph.GetVertices().ForEach(v => v.UnVisit());
            var list = new List<DistanceModel<T>> { new DistanceModel<T>(start, 0, start)};
            var matrix = graph.GetMatrix();
            var current = start; 
            while (graph.UnVisitedVertices().Any())
            {
                current.Visit(); 
                for(int i = 0; i < graph.GetMaxSize(); i++)
                {
                    var neighbour = graph.GetVertices().FirstOrDefault(v => v.GetIndex() == i);
                    if (graph.AreAdjacent(current, neighbour))
                    {
                        var tentativeDist = GetModel(list, current).Distance() + matrix[current.GetIndex(), i];
                        if (ContainsAndGreater(list, neighbour, tentativeDist))
                        {
                            var neighbourModel = GetModel(list, neighbour);
                            neighbourModel.ChangeDistance(tentativeDist);
                            neighbourModel.ChangePrevios(current);
                        }
                        else if (!Contains(list, neighbour))
                        {
                            list.Add(new DistanceModel<T>(neighbour, tentativeDist, current));
                        }
                    }
                }
                current = MinUnvisitedVertex(list);
            }
            return list;

        }
        private IVertex<T> MinUnvisitedVertex(List<DistanceModel<T>> list)
        {
            var newList = list.OrderBy(m => m.Distance());
            IVertex<T> result=null;
            foreach(var model in newList)
            {
                if (!model.Current().IsVisited())
                {
                    result = model.Current();
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
