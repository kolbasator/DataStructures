using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IGraphViaMatrixVertex<T>
    {
        T GetData(); 
        int GetIndex(); 
    }
}
