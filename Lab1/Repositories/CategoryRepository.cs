using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context _context) : base(_context)
        {
        }

        public Category GetCateWithProducts(int id)
        {
            return Context.Category.Include(c=>c.Products).FirstOrDefault(c=>c.Id == id);
        }
    }
}
