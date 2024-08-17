using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

    }
}
