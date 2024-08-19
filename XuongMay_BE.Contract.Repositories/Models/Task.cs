using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Contract.Repositories.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> completion_rate { get; set; }
        public string Note { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
    }
}
