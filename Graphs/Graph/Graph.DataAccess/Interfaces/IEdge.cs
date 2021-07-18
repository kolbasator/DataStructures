using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IEdge<T>
    {
        IVertex<T> FirstVertex();
        IVertex<T> SecondVertex();
    }
}
