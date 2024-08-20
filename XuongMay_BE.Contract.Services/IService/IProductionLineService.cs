using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;
namespace XuongMay_BE.Contract.Services.IService
{
    public interface IProductionLineService
    {
        Task<IList<ProductionLine>> GetAll();
        Task<ProductionLine?> GetById(object id);
        Task Add(ProductionLine productionline);
        Task Update(ProductionLine productionline);
        Task Delete(object id);
    }
}