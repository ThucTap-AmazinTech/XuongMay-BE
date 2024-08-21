using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Role : BaseModel
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            User_Roles = new HashSet<User_Roles>();
        }

 

        [Required]
        public string Name { get; set; }

        [Required]
        public string Note { get; set; }

      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Roles> User_Roles { get; set; }
    }
}
