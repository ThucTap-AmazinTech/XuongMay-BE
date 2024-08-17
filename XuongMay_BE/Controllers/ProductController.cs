using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Data;
using XuongMay_BE.Models;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return NotFound("Product not found!");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products
                                          .Include(p => p.Category) // Nếu cần cập nhật Category
                                          .Include(p => p.OrderDetails) // Nếu cần cập nhật OrderDetails
                                          .Include(p => p.Tasks) // Nếu cần cập nhật Tasks
                                          .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct is null)
                return NotFound("Product not found!");

            // Cập nhật các thuộc tính
            dbProduct.Name = product.Name;
            dbProduct.Category = product.Category; // Cập nhật Category nếu cần
            dbProduct.OrderDetails = product.OrderDetails; // Cập nhật OrderDetails nếu cần
            dbProduct.Tasks = product.Tasks; // Cập nhật Tasks nếu cần

            await _context.SaveChangesAsync();

            // Trả về đối tượng Product đã được cập nhật
            return Ok(dbProduct);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return NotFound("Product not found!");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }
    }
}
