using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.App;
using XuongMay_BE.ViewModels.ViewModels;

namespace XuongMay_BE.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(IUnitOfWork unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) 
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<string> SignInAsync(SignInViewModel signInViewModel)
        {
            var user = await _userManager.FindByEmailAsync(signInViewModel.UserName);
            var passwordValid = await _userManager.CheckPasswordAsync(user, signInViewModel.Password);

            if (!passwordValid || user is null)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInViewModel.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

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

            var result =  await _userManager.CreateAsync(user, signUpViewModel.Password);

            if (result.Succeeded)
            {
                // Kiểm tra các Role đã tồn tại
                if (!await _roleManager.RoleExistsAsync(AppRole.Administrator))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Administrator));
                }
                if (!await _roleManager.RoleExistsAsync(AppRole.LineManager))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.LineManager));
                }
                if (!await _roleManager.RoleExistsAsync(AppRole.DefaultRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.DefaultRole));
                }
                await _userManager.AddToRoleAsync(user, AppRole.DefaultRole);
            }
            return result;
        }
    }
}
