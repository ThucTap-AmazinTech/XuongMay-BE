using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        public readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(OrderDetail orderDetail)
        {
            orderDetail.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<OrderDetail> genericRepository = _unitOfWork.GetGenericRepository<OrderDetail>();
            await genericRepository.AddAsync(orderDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<OrderDetail> genericRepository = _unitOfWork.GetGenericRepository<OrderDetail>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<OrderDetail>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<OrderDetail>().GetAllAsync();
        }

        public Task<OrderDetail?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<OrderDetail>().GetByIdAsync(id);
        }

        public async Task Update(OrderDetail orderDetail)
        {
            IGenericRepository<OrderDetail> genericRepository = _unitOfWork.GetGenericRepository<OrderDetail>();
            await genericRepository.UpdateAsync(orderDetail);
            await _unitOfWork.SaveAsync();
        }
    }
}
