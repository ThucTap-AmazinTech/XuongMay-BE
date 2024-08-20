using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class User : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Order>? Orders { get; }
        public virtual ICollection<ProductionLine>? ProductionLines { get; }
        public virtual ICollection<User_Role>? User_Role { get; }
    }
}
