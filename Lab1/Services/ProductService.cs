using Lab1.DTO;
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

        public IEnumerable<ProductWithIdDTO> GetAll()
        {
            IEnumerable<Product> products =  ProductRepository.GetAll(p => p.isDeleted == false);
            List<ProductWithIdDTO> productWithIdDTOs = new List<ProductWithIdDTO>();
            foreach (var item in products)
            {
                productWithIdDTOs.Add(new ProductWithIdDTO() {Id = item.Id,Name = item.Name , Description = item.Description , Price = item.Price , CategoryId = item.CategoryId });
            }
            return productWithIdDTOs;
        }

        public Product GetById(int id)
        {
            return ProductRepository.GetById(id, p => p.Id == id && p.isDeleted == false);
        }

        public IEnumerable<Product> Get(Func<Product, bool> where)
        {
            return ProductRepository.Get(where);
        }
        public Product Insert(ProductWithoutIdDTO newProd)
        {
            Product product = new Product()
            { Name = newProd.Name, Description = newProd.Description, Price = newProd.Price ,CategoryId = newProd.CategoryId};
            ProductRepository.Insert(product);
            ProductRepository.Save();
            return product;
        }
        public void Insert(Product newProd)
        {
            ProductRepository.Insert(newProd);
            ProductRepository.Save();
        }

            public void Update(Product product,ProductWithoutIdDTO newProd)
        {
            product.Name = newProd.Name;
            product.Description = newProd.Description;
            product.Price = newProd.Price;
            product.CategoryId = newProd.CategoryId;
            ProductRepository.Update(product);
            ProductRepository.Save();
        }

        public void Delete(int id) 
        {
            ProductRepository.SoftDelete(id);
        }
    }
}
