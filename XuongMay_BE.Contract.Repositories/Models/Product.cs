using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set;}
        public virtual ICollection<OrderDetail> OrderDetails { get; }
        public virtual ICollection<Task> Tasks { get; }
    }
}
