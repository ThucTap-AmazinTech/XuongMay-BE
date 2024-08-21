using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class OrderDetail : BaseModel
    {
        public int? Quantity { get; set; }

        [Required]
        public string Note { get; set; }

        [StringLength(450)]
        public string OrderId { get; set; }

        [StringLength(450)]
        public string ProductId { get; set; }

      
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
