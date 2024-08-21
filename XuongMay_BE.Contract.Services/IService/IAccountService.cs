using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.ViewModels.ViewModels;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface IAccountService
    {
        Task<string> SignInAsync(SignInViewModel signInViewModel);
        Task<IdentityResult> SignUpAsync(SignUpViewModel signUpViewModel);
    }
}
