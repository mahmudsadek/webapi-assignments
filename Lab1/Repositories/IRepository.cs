namespace Lab1.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        List<T> Get(Func<T, bool> where);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);

        void Save();
    }
}
}
