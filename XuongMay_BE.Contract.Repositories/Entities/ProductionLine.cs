using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class ProductionLine : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionLine()
        {
            Tasks = new HashSet<Task>();
        }


        [Required]
        public string Name { get; set; }

        [StringLength(450)]
        public string ManagerId { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
