using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services.Service;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticateController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Validate(string username, string password)
        {
            User user = await _userService.Login(username, password);
            if (user is null)
            {
                return NotFound("User not found! Validation failed!");
            }
            return Ok(new
            {
                Success = true,
                Token = GenerateToken(user)
            });
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:SecretKey"));
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("TokenId", Guid.NewGuid().ToString("N"))
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(User user)
        {
            await _userService.Add(user);
            return Ok();
        }
    }
}
