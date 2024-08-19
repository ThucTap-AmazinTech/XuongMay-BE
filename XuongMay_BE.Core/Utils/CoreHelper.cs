using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuongMay_BE.Core.Utils
{
    public static class CoreHelper
    {
        public static DateTimeOffset SystemTimeNow => TimeHelper.ConvertToUTCPlus7(DateTimeOffset.Now);
    }
}
