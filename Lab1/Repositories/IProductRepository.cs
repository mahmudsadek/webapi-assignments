using Lab1.Models;

namespace Lab1.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void SoftDelete(int id);
        
    }
}
