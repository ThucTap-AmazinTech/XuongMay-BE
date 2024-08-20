//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using XuongMay_BE.Data;
//using XuongMay_BE.Contract.Repositories.Entities;

//namespace XuongMay_BE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly DataContext _context;
//        public ProductController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<Product>>> GetAllProducts()
//        {
//            var products = await _context.Products.ToListAsync();
//            return Ok(products);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Product>> GetProduct(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            if (product is null)
//                return NotFound("Product not found!");
//            return Ok(product);
//        }

//        [HttpPost]
//        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
//        {
//            _context.Products.Add(product);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Products.ToListAsync());
//        }

//        [HttpPut]
//        public async Task<ActionResult<Product>> UpdateProduct(Product product)
//        {
//            var dbProduct = await _context.Products.FindAsync(product.Id);
//            if (dbProduct is null)
//                return NotFound("Product not found!");
//            dbProduct.Name = product.Name;
//            var dbCategory = await _context.Categories.FindAsync(product.CategoryId);
//            if (dbCategory is null)
//                return NotFound("Category not found!");
//            dbProduct.CategoryId = product.CategoryId;
//            dbProduct.Category = dbCategory;
//            dbCategory.Products.Add(dbProduct);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Products.FindAsync(dbProduct.Id));
//        }


//        [HttpDelete("{id}")]
//        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            if (product is null)
//                return NotFound("Product not found!");
//            _context.Products.Remove(product);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Products.ToListAsync());
//        }
//    }
//}
