using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Models;
using XuongMay_BE.Contract.Services.IService;

namespace XuongMay_BE.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IList<Category>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Category>().GetAllAsync();
        }
    }
}
