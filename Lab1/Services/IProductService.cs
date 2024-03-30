using Lab1.Models;
using Lab1.ViewModels;

namespace Lab1.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(); 
        Product GetById(int id);

        Product Insert(ProductViewModel newProd);
        void Insert(Product newProd);


        void Update(Product product ,ProductViewModel newProd);

        void Delete(int id);

        IEnumerable<Product> Get(Func<Product,bool> where);
    }
}
