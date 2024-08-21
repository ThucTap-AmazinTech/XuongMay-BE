using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
  
    public interface ITasksService
    {
        Task<IList<Tasks>> GetAll();
        Task<Tasks?> GetById(object id);
        Task Add(Tasks task);
        Task Update(Tasks task);
        Task Delete(object id);
    }
}
