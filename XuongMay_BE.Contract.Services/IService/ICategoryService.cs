
using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll(); 
        Task<Category?> GetById(object id);
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(object id);
    }
}
