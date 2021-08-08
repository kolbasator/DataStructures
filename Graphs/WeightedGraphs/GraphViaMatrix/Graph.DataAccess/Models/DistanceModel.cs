using Graph.DataAccess.Interfaces;

namespace Graph.DataAccess.Models
{
    public class DistanceModel<T>
    {
        private IVertex<T> _current;
        private int _dist;
        private IVertex<T> _previos;
        public DistanceModel(IVertex<T> current, int distance, IVertex<T> previos)
        {
            _current = current;
            _dist = distance;
            _previos = previos;
        } 
        public IVertex<T> Current()
        {
            return _current;
        }
        public IVertex<T> Previos()
        {
            return _previos;
        }
        public int Distance()
        {
            return _dist;
        }
        public void ChangeCurrent(IVertex<T> vertex)
        {
            _current = vertex;
        }
        public void ChangePrevios(IVertex<T> vertex)
        {
            _previos = vertex; 
        }
        public void ChangeDistance(int distance)
        {
            _dist = distance;
        }
        public string GetData()
        {
            return $"Current-{_current.GetData()},Distance-{_dist},Previos-{_previos.GetData()}";
        }
    }
}
