using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
