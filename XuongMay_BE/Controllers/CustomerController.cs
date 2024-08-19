//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using XuongMay_BE.Contract.Repositories.Models;
//using XuongMay_BE.Data;

//namespace XuongMay_BE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public CustomerController(DataContext context)
//        {
//            _context = context;
//        }
//        //Get all customer
//        [HttpGet]
//        public async Task<ActionResult<List<Category>>> GetAllCustomer()
//        {
//            var customers = await _context.Customers.ToListAsync();
//            return Ok(customers);
//        }
//        //Get customer by ID
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Category>> GetCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer is null)
//                return NotFound("Customer not found!");
//            return Ok(customer);
//        }
//        //Add new customer
//        [HttpPost]
//        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
//        {
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Customers.ToListAsync());
//        }
//        //Update customer by ID
//        [HttpPut]
//        public async Task<ActionResult<Category>> UpdateCustomer(Customer customer)
//        {
//            var dbCustomer = await _context.Categories.FindAsync(customer.Id);
//            if (dbCustomer is null)
//                return NotFound("Category not found!");
//            dbCustomer.Name = dbCustomer.Name;
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Categories.FindAsync(dbCustomer.Id));
//        }
//        //Delete customer by ID
//        [HttpDelete]
//        public async Task<ActionResult<List<Category>>> DeleteCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer is null)
//                return NotFound("Customer not found!");
//            _context.Remove(customer);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Categories.ToListAsync());
//        }

//    }
//}
