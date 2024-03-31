using Lab1.DTO;
using Lab1.Models;
using Lab1.Services;
using Lab1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<ProductWithIdDTO> products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            Product product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {

            IEnumerable<Product> products = _productService.Get(p => p.Name == name && p.isDeleted == false);
            if (products.Count() == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("Price")]
        public IActionResult Price(decimal price)
        {

            IEnumerable<Product> products = _productService.Get(p => p.Price >= price && p.isDeleted == false);
            if (products.Count() == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("PriceBetween")]
        public IActionResult PriceBetween(decimal lowprice, decimal highprice)
        {

            IEnumerable<Product> products = _productService.Get(p => p.Price >= lowprice && p.Price <= highprice && p.isDeleted == false);
            if (products.Count() == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(ProductWithoutIdDTO newProduct)
        {
            if (ModelState.IsValid)
            {
                Product p =  _productService.Insert(newProduct);
                return CreatedAtAction("GetById",new { id = p.Id }, newProduct);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Edit(int id, ProductWithoutIdDTO Modefiedproduct)
        {
            Product OldProduct = _productService.GetById(id);
            if (OldProduct == null)
            {
                return BadRequest("Wrong Id");
            }
            _productService.Update(OldProduct, Modefiedproduct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) 
        {
            try 
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
 
}
