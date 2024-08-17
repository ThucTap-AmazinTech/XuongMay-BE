using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductionLine> ProductionLines { get; set; }
        public virtual ICollection<User_Role> User_Roles { get; set; }
    }
}
