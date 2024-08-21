using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;


namespace XuongMay_BE.Contract.Services.IService
{
    public interface IOrderDetailDetailService
    {
        Task<IList<OrderDetail>> GetAll();
        Task<OrderDetail?> GetById(object id);
        Task Add(OrderDetail orderDetail);
        Task Update(OrderDetail orderDetail);
        Task Delete(object id);
    }
}
