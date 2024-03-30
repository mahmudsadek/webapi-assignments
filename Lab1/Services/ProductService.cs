using Lab1.Models;
using Lab1.Repositories;

namespace Lab1.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository ProductRepository;
        public ProductService(IProductRepository productRepository) 
        {
            ProductRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductRepository.GetAll();
        }
    }
}
