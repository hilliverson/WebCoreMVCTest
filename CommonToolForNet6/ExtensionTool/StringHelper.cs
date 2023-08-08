using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ExtensionTool
{
    public static class StringHelper
    {
        public static DateTime ToDateTime(this string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            DateTime dateTime;
            if (DateTime.TryParse(str, out dateTime))
            {
                return dateTime;    
            }
            else
            {
                throw new ArgumentException($" {nameof(str)} string can not transfer to DateTime");
            }
        }
    }
}
