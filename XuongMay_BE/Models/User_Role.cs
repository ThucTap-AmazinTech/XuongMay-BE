using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class User_Role
    {
        [Key]
        public string Id {  get; set; }
        public string User_ID { get; set; }
        public string Role_ID { get; set; }
        public string Note { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
