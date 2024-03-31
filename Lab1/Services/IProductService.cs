using Lab1.DTO;
using Lab1.Models;
using Lab1.ViewModels;

namespace Lab1.Services
{
    public interface IProductService
    {
        IEnumerable<ProductWithIdDTO> GetAll(); 
        Product GetById(int id);

        Product Insert(ProductWithoutIdDTO newProd);
        void Insert(Product newProd);


        void Update(Product product ,ProductWithoutIdDTO newProd);

        void Delete(int id);

        IEnumerable<Product> Get(Func<Product,bool> where);
    }
}
