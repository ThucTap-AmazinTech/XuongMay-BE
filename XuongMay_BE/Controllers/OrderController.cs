
using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Data;
using XuongMay_BE.Models;
using Microsoft.EntityFrameworkCore;
namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }
        //Get all Order
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAlOrder()
        {
            var orfer = await _context.Orders.ToListAsync();
            return Ok(orfer);
        }
        //Get Order by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return NotFound("Order not found!");
            return Ok(order);
        }
        //Add new Order
        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }
        //Update Order by ID
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateOrder(Order order)
        {
            var dbOrder = await _context.Categories.FindAsync(order.Id);
            if (dbOrder is null)
                return NotFound("Category not found!");
            dbOrder.Name = dbOrder.Name;
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.FindAsync(dbOrder.Id));
        }
        //Delete Order by ID
        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return NotFound("Order not found!");
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }
    }
}
