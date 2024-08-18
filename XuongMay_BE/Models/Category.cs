using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Category> Products { get; set; }
    }
}
