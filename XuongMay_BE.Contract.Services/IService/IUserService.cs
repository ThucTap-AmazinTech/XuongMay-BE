using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Models;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();
        Task<User?> GetById(object id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(object id);
    }
}
