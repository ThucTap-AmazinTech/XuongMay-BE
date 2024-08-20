using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class ProductionLineService : IProductionLineService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ProductionLineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(ProductionLine productionline)
        {
            productionline.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<ProductionLine> genericRepository = _unitOfWork.GetGenericRepository<ProductionLine>();
            await genericRepository.AddAsync(productionline);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<ProductionLine> genericRepository = _unitOfWork.GetGenericRepository<ProductionLine>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<ProductionLine>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<ProductionLine>().GetAllAsync();
        }

        public Task<ProductionLine?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<ProductionLine>().GetByIdAsync(id);
        }

        public async Task Update(ProductionLine productionline)
        {
            IGenericRepository<ProductionLine> genericRepository = _unitOfWork.GetGenericRepository<ProductionLine>();
            await genericRepository.UpdateAsync(productionline);
            await _unitOfWork.SaveAsync();
        }
    }
}