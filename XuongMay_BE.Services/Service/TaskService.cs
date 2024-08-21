using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class TaskService : ITaskService
    {
        public readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Task task)
        {
            task.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<Task> genericRepository = _unitOfWork.GetGenericRepository<Task>();
            await genericRepository.AddAsync(task);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Task> genericRepository = _unitOfWork.GetGenericRepository<Task>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Task>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Task>().GetAllAsync();
        }

        public Task<Task?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Task>().GetByIdAsync(id);
        }

        public async Task Update(Task Task)
        {
            IGenericRepository<Task> genericRepository = _unitOfWork.GetGenericRepository<Task>();
            await genericRepository.UpdateAsync(Task);
            await _unitOfWork.SaveAsync();
        }
    }
}
