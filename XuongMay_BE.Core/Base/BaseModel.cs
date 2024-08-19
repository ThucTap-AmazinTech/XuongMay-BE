using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Core.Utils;

namespace XuongMay_BE.Core.Base
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid().ToString("N");
            CreatedAt = UpdatedAt = CoreHelper.SystemTimeNow;
        }

        [Key]
        public string Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset DeletedAt { get; set; }
    }
}
