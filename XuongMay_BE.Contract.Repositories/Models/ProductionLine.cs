using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class ProductionLine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Task> Tasks { get; }
    }
}
