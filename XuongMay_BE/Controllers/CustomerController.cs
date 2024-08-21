using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.Query;


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
        public async Task<IActionResult> GetAllCustomers([FromQuery] QueryObject query)
        {
            IList<Customer> categories = await _CustomerService.GetAll();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return Ok(categories.Skip(skipNumber).Take(query.PageSize));
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
            await _CustomerService.Add(customer);
            return Ok(await _CustomerService.GetAll());
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
