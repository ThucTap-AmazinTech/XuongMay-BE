using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Models;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll(); 
        Task<Category?> GetById(object id);
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(object id);
    }
}
