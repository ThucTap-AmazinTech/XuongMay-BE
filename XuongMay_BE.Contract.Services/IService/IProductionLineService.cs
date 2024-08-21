using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface IProductionLineService
    {
        Task<IList<ProductionLine>> GetAll();
        Task<ProductionLine?> GetById(object id);
        Task Add(ProductionLine productionLine);
        Task Update(ProductionLine productionLine);
        Task Delete(object id);
    }
}
