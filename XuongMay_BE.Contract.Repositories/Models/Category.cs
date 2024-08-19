using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; }
    }
}
