using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Note { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
