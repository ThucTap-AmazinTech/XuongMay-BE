using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class TasksService : ITasksService
    {
        public readonly IUnitOfWork _unitOfWork;

        public TasksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Tasks task)
        {
            task.Id = Guid.NewGuid().ToString("N");
            IGenericRepository<Tasks> genericRepository = _unitOfWork.GetGenericRepository<Tasks>();
            await genericRepository.AddAsync(task);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Task> genericRepository = _unitOfWork.GetGenericRepository<Task>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Tasks>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Tasks>().GetAllAsync();
        }

        public Task<Tasks?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Tasks>().GetByIdAsync(id);
        }

        public async Task Update(Tasks tasks)
        {
            IGenericRepository<Tasks> genericRepository = _unitOfWork.GetGenericRepository<Tasks>();
            await genericRepository.UpdateAsync(tasks);
            await _unitOfWork.SaveAsync();
        }
    }
}
