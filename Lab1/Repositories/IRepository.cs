namespace Lab1.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> where);
        T GetById(int id);
        T GetById(int id, Func<T, bool> where);
        List<T> Get(Func<T, bool> where);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);

        void Save();
    }
}
