using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class User : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            ProductionLines = new HashSet<ProductionLine>();
            User_Roles = new HashSet<User_Roles>();
        }

     

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Image { get; set; }

       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ProductionLine> ProductionLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<User_Roles> User_Roles { get; set; }
    }
}
