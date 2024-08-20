using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Contract.Repositories.Models;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services;


namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            IList<Customer> categories = await _CustomerService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            Customer Customer = await _CustomerService.GetById(id);
            if (Customer is null)
                return NotFound("Customer not found!");
            return Ok(Customer);
        }

    
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            // Nếu Orders là null, khởi tạo nó với mảng rỗng
           

            await _CustomerService.Add(customer);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                await _CustomerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Customer not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer Customer)
        {
            try
            {
                await _CustomerService.Update(Customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Customer not found!");
            }
        }
    }
}
