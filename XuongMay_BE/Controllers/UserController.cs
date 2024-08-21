using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.Query;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers([FromQuery] QueryObject query)
        {
            IList<User> users = await _userService.GetAll();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return Ok(users.Skip(skipNumber).Take(query.PageSize));
        }
    }
}
