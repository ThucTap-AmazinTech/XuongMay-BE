using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Data;
using XuongMay_BE.Models;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return NotFound("Category not found!");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(category.Id);
            if (dbCategory is null)
                return NotFound("Category not found!");
            dbCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.FindAsync(category.Id));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return NotFound("Category not found!");
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }
    }
}
