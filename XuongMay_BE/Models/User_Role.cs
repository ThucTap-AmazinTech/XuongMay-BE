using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class User_Role
    {
        [Key]
        public int Id {  get; set; }
        public string Note { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
