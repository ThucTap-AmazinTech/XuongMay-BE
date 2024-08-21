using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public virtual ICollection<User_Role> User_Role { get; }
    }
}
