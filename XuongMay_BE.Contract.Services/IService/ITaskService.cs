using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface ITaskService
    {
        Task<IList<Task>> GetAll();
        Task<Task?> GetById(object id);
        Task Add(Task task);
        Task Update(Task task);
        Task Delete(object id);
    }
}
