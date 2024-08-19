using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Nullable<decimal> Total_amount { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; }
        public virtual ICollection<Task> Tasks { get; }
    }
}
