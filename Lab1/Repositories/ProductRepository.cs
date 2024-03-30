using Lab1.Models;

namespace Lab1.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Context _context) : base(_context)
        {
        }
    }
}
