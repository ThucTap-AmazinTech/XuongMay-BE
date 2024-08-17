using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class OrderDetail
    {
        [Key]
        public string Order_ID { get; set; }
        public string Product_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Note { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
