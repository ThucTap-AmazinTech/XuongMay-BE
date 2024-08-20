using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Order> Orders { get; }
        public virtual ICollection<ProductionLine> ProductionLines { get; }
        public virtual ICollection<User_Role> User_Role { get; }
    }
}
