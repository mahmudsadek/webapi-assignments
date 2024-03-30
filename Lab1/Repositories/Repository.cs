using Lab1.Models;

namespace Lab1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context Context;
        public Repository(Context _context)
        {
            Context = _context;
        }
        public void Delete(T item)
        {
            Context.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public List<T> Get(Func<T, bool> where)
        {
            return Context.Set<T>().Where(where).ToList();
        }
        public void Insert(T item)
        {
            Context.Add(item);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Update(T item)
        {
            Context.Update(item);
        }
    }
}
