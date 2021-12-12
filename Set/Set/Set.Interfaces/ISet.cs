namespace Set.Interfaces
{
    public interface ISet<T>
    {
        void Insert(T entity);
        T Search(T entity);
        T Erase(T entity);
        int Count(T entity);
    }
}
