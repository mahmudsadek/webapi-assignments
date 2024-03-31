using Lab1.Models;

namespace Lab1.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCateWithProducts(int id);
    }
}
