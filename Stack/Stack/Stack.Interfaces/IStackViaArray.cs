using Stack.Interfaces; 

namespace Stack.Interfaces
{
    public interface IStackViaArray<T> : IStack<T>
    {
        bool IsFull { get; }
    }
}
