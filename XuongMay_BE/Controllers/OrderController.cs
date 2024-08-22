using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.Query;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] QueryObject query)
        {
            IList<Order> orders = await _OrderService.GetAll();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return Ok(orders.Skip(skipNumber).Take(query.PageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            Order order = await _OrderService.GetById(id);
            if (order is null)
                return NotFound("Order not found!");
            return Ok(order);
        }
       

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            await _OrderService.Add(order);
            return Ok(await _OrderService.GetAll());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            try
            {
                await _OrderService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Order not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                await _OrderService.Update(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Order not found!");
            }
        }
    }
}
