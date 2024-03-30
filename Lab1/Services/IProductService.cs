using Lab1.Models;

namespace Lab1.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(); 
    }
}
