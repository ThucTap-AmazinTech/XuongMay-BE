using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Entities;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product?> GetById(object id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(object id);
    }
}