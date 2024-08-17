using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetels { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
