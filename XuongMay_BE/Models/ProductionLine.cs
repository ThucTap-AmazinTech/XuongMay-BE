using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class ProductionLine
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manage_ID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
