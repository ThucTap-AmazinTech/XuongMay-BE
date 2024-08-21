using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services.Service;
using XuongMay_BE.ViewModels.ViewModels;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public AuthenticateController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            var result = await _accountService.SignInAsync(signInViewModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            var result = await _accountService.SignUpAsync(signUpViewModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest(result.Errors);
        }
    }
}
