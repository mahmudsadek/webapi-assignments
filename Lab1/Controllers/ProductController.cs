using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        ProductController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            IEnumerable<Product> products = _productService.GetAll();
            return Ok(products);
        }
    }
}
