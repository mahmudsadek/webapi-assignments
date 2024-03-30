using Lab1.Models;

namespace Lab1.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Context _context) : base(_context)
        {
        }

        public void SoftDelete(int id)
        {
            Product product = GetById(id);
            if (product != null)
            {
                product.isDeleted = true;
                product.DeletedTime = DateTime.Now;
                Save();
            }
            return;
        }
    }
}
