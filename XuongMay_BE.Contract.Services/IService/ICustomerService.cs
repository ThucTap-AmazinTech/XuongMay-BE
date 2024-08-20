using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Models;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Contract.Services.IService
{
    public interface ICustomerService
    {
      
            Task<IList<Customer>> GetAll();
            Task<Customer?> GetById(object id);
            Task Add(Customer customer);
            Task Update(Customer customer);
            Task Delete(object id);
        
    }
}
