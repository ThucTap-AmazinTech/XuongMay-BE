using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class User_Role : BaseModel
    {
        public string Note { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
