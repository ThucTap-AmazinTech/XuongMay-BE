using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class User_Roles : BaseModel
    {
        [Required]
        public string Note { get; set; }

        [Required]
        [StringLength(450)]
        public string RoleId { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
