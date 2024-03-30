using Lab1.Models;
using Lab1.Repositories;
using Lab1.ViewModels;

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
            return ProductRepository.GetAll(p => p.isDeleted == false);
        }

        public Product GetById(int id)
        {
            return ProductRepository.GetById(id, p => p.Id == id && p.isDeleted == false);
        }

        public IEnumerable<Product> Get(Func<Product, bool> where)
        {
            return ProductRepository.Get(where);
        }
        public Product Insert(ProductViewModel newProd)
        {
            Product product = new Product()
            { Name = newProd.Name, Description = newProd.Description, Price = newProd.Price };
            ProductRepository.Insert(product);
            ProductRepository.Save();
            return product;
        }
        public void Insert(Product newProd)
        {
            ProductRepository.Insert(newProd);
            ProductRepository.Save();
        }

            public void Update(Product product,ProductViewModel newProd)
        {
            product.Name = newProd.Name;
            product.Description = newProd.Description;
            product.Price = newProd.Price;
            ProductRepository.Update(product);
            ProductRepository.Save();
        }

        public void Delete(int id) 
        {
            ProductRepository.SoftDelete(id);
        }
    }
}
