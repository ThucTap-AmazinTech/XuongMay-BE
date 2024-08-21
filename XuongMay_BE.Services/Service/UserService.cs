using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Core.Utils;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Contract.Repositories.Entities;

namespace XuongMay_BE.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(User user)
        {
            IGenericRepository<User> genericRepository = _unitOfWork.GetGenericRepository<User>();
            user.Id = Guid.NewGuid().ToString("N");
            user.CreatedAt = CoreHelper.SystemTimeNow;
            await genericRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<User> genericRepository = _unitOfWork.GetGenericRepository<User>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<User>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<User>().GetAllAsync();
        }

        public Task<User?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<User>().GetByIdAsync(id);
        }

        public async Task<User?> Login(string username, string password)
        {
            IGenericRepository<User> genericRepository = _unitOfWork.GetGenericRepository<User>();
            return genericRepository.Entities.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public Task Signup(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User user)
        {
            IGenericRepository<User> genericRepository = _unitOfWork.GetGenericRepository<User>();
            user.Id = Guid.NewGuid().ToString("N");
            user.UpdatedAt = CoreHelper.SystemTimeNow;
            await genericRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
