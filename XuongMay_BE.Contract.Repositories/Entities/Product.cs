using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string? CategoryId { get; set; }
        public virtual Category? Category { get; set;}
        public virtual ICollection<OrderDetail>? OrderDetails { get; }
        public virtual ICollection<Task>? Tasks { get; }
    }
}
