using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.Utils;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Category category)
        {
            IGenericRepository<Category> genericRepository = _unitOfWork.GetGenericRepository<Category>();
            category.CreatedAt = CoreHelper.SystemTimeNow;
            category.DeletedAt = CoreHelper.SystemTimeNow;
            await genericRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Category> genericRepository = _unitOfWork.GetGenericRepository<Category>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Category>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Category>().GetAllAsync();
        }

        public Task<Category?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Category>().GetByIdAsync(id);
        }

        public async Task Update(Category category)
        {
            IGenericRepository<Category> genericRepository = _unitOfWork.GetGenericRepository<Category>();
            category.UpdatedAt = CoreHelper.SystemTimeNow;
            await genericRepository.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
