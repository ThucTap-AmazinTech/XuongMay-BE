using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface IUserRolesService
    {
        Task<IList<User_Roles>> GetAll();
        Task<Order?> GetById(object id);
        Task Add(Order Order);
        Task Update(Order Order);
        Task Delete(object id);
    }
}
