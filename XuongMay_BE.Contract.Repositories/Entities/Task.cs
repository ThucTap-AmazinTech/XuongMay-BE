using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Task : BaseModel
    {
        public int? Completion_rate { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        [StringLength(450)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(450)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(450)]
        public string ProductionLineId { get; set; }

       
        public virtual Order Order { get; set; }

        public virtual ProductionLine ProductionLine { get; set; }

        public virtual Product Product { get; set; }
    }
}
