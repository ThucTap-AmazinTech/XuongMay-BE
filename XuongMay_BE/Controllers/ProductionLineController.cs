using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController : ControllerBase
    {
        private readonly IProductionLineService _ProductionLineService;

        public ProductionLineController(IProductionLineService ProductionLineService)
        {
            _ProductionLineService = ProductionLineService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductionLines()
        {
            IList<ProductionLine> categories = await _ProductionLineService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionLineById(string id)
        {
            ProductionLine ProductionLine = await _ProductionLineService.GetById(id);
            if (ProductionLine is null)
                return NotFound("Customer not found!");
            return Ok(ProductionLine);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductionLine([FromBody] ProductionLine productionline)
        {
            // Nếu Orders là null, khởi tạo nó với mảng rỗng


            await _ProductionLineService.Add(productionline);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProductionLine(string id)
        {
            try
            {
                await _ProductionLineService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("ProductionLine not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductionLine(ProductionLine ProductionLine)
        {
            try
            {
                await _ProductionLineService.Update(ProductionLine);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("ProductionLine not found!");
            }
        }
    }
}