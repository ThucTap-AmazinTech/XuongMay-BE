using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; }
    }
}
