using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.Query;


namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] QueryObject query)
        {
            IList<Product> products = await _ProductService.GetAll();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return Ok(products.Skip(skipNumber).Take(query.PageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            Product Product = await _ProductService.GetById(id);
            if (Product is null)
                return NotFound("Product not found!");
            return Ok(Product);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            // Nếu Orders là null, khởi tạo nó với mảng rỗng


            await _ProductService.Add(product);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                await _ProductService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Product not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product Product)
        {
            try
            {
                await _ProductService.Update(Product);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Product not found!");
            }
        }
    }
}