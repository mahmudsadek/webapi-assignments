using Lab1.DTO;
using Lab1.Models;
using Lab1.Repositories;

namespace Lab1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoryWithProductNameDTO GetById(int id)
        {
            Category category = categoryRepository.GetCateWithProducts(id);
            if (category == null)
            {
                return null;
            }
            CategoryWithProductNameDTO cat = new() 
            {Id = category.Id,Name = category.Name , ProductNames = new List<string>()};
            if (category.Products != null)
            { 
                foreach (Product p in category.Products)
                {
                    cat.ProductNames.Add(p.Name);
                }
            }
            return cat;
        }

        public Category Insert(CategoryWithoutIdDTO category)
        {
            Category cat = new Category()
            { Name = category.Name};
            categoryRepository.Insert(cat);
            categoryRepository.Save();
            return cat;
        }
    }
}
