using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Models;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll(); 
        Task 
    }
}
