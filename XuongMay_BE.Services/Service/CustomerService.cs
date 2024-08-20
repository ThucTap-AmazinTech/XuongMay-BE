using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Models;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    internal class CustomerService : ICustomerService
    {
        public readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<Customer> genericRepository = _unitOfWork.GetGenericRepository<Customer>();
            await genericRepository.AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Customer> genericRepository = _unitOfWork.GetGenericRepository<Customer>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Customer>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Customer>().GetAllAsync();
        }

        public Task<Customer?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Customer>().GetByIdAsync(id);
        }

        public async Task Update(Customer customer)
        {
            IGenericRepository<Customer> genericRepository = _unitOfWork.GetGenericRepository<Customer>();
            await genericRepository.UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
        }
    }
}
