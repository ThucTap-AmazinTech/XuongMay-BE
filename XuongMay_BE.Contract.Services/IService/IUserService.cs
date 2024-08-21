using XuongMay_BE.Contract.Repositories.Entities;
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
        Task<User?> Login(string username, string password);
        Task Signup(User user);
    }
}
