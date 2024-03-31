using Lab1.DTO;
using Lab1.Models;

namespace Lab1.Services
{
    public interface ICategoryService
    {
        CategoryWithProductNameDTO GetById(int id);
        Category Insert(CategoryWithoutId category);
    }
}
