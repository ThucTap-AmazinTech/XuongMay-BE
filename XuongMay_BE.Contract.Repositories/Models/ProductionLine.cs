using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class ProductionLine : BaseModel
    {
        public string Name { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Task> Tasks { get; }
    }
}
