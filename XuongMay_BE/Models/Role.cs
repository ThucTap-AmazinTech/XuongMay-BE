using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Role
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public virtual ICollection<User_Role> User_Role { get; set; }
    }
}
