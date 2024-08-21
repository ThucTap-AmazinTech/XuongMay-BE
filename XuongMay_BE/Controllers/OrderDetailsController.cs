using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            IList<OrderDetail> orderDetails = await _orderDetailService.GetAll();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            OrderDetail orderDetail = await _orderDetailService.GetById(id);
            if (orderDetail is null)
                return NotFound("Order not found!");
            return Ok(orderDetail);
        }


        [HttpPost]
        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetail orderDetail)
        {
            await _orderDetailService.Add(orderDetail);
            return Ok(await _orderDetailService.GetAll());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(string id)
        {
            try
            {
                await _orderDetailService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Order not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                await _orderDetailService.Update(orderDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Order not found!");
            }
        }
    }
}
