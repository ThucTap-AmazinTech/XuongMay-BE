using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.ViewModels.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace XuongMay_BE.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> SignInAsync(SignInViewModel signInViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInViewModel.UserName, signInViewModel.Password, false, false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInViewModel.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
            };

            var authenticationKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(6),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenticationKey, SecurityAlgorithms.HmacSha512Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpViewModel signUpViewModel)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString("N"),
                Fullname = signUpViewModel.FullName,
                Email = signUpViewModel.Email,
                UserName = signUpViewModel.Email
            };

            return await _userManager.CreateAsync(user, signUpViewModel.Password);
        }
    }
}
