using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCategories()
        {
            IList<Category> categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            Category category = await _categoryService.GetById(id);
            if (category is null)
                return NotFound("Category not found!");
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryService.Add(category);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                await _categoryService.Delete(id);
                return Ok();
            } catch (Exception ex)
            {
                return NotFound("Category not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                await _categoryService.Update(category);
                return Ok();
            } catch (Exception ex)
            {
                return NotFound("Category not found!");
            }
        }
    }
}
