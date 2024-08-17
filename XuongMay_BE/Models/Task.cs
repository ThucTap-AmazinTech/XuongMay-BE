using System.ComponentModel.DataAnnotations;

namespace XuongMay_BE.Models
{
    public class Task
    {
        [Key]
        public string Id { get; set; }
        public string Order_ID { get; set; }
        public string ProductionLine_ID { get; set; }
        public string Product_ID { get; set; }
        public Nullable<int> completion_rate { get; set; }
        public string Note { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
    }
}
