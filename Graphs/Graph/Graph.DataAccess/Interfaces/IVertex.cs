 using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DataAccess.Interfaces
{
    public interface IVertex<T>
    { 
        T GetData(); 
    }
}
