using Lab1.DTO;
using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id) 
        {
            CategoryWithProductNameDTO category =  categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(CategoryWithoutIdDTO category) 
        {
            if (ModelState.IsValid)
            {
                Category c  = categoryService.Insert(category);
                return CreatedAtAction("GetById", new { id = c.Id }, category);
            }
            return BadRequest(ModelState);
        }
    }
}
