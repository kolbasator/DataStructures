namespace Stack.Interfaces
{
    public interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Push(T entity);
        T Peek();
        T Pop();
    }
}
