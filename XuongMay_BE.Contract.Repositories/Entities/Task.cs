using System.ComponentModel.DataAnnotations;
using XuongMay_BE.Core.Base;

namespace XuongMay_BE.Contract.Repositories.Entities
{
    public class Task : BaseModel
    {
        public Nullable<int> completion_rate { get; set; }
        public string Note { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
    }
}
