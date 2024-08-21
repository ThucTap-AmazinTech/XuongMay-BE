using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class OrderService : IOrderService
    {
        public readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Order order)
        {
            order.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<Order> genericRepository = _unitOfWork.GetGenericRepository<Order>();
            await genericRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Order> genericRepository = _unitOfWork.GetGenericRepository<Order>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Order>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Order>().GetAllAsync();
        }

        public Task<Order?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Order>().GetByIdAsync(id);
        }

        public async Task Update(Order order)
        {
            IGenericRepository<Order> genericRepository = _unitOfWork.GetGenericRepository<Order>();
            await genericRepository.UpdateAsync(order);
            await _unitOfWork.SaveAsync();
        }
    }
}
