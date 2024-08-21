using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Tasks : BaseModel
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
        [JsonIgnore]
        public string ProductionLineId { get; set; }

    }
}
