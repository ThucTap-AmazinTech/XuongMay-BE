using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class OrderDetail : BaseModel
    {
        public Nullable<int> Quantity { get; set; }
        public string Note { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
