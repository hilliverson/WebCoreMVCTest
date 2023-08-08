using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ExtensionTool
{
    public static class ListHelper
    {
        public static List<T> TrimAllString<T>(this List<T> list)
        {
            foreach(var item in list)
            {
                Type type = item.GetType();
                // 取得所有屬性的 PropertyInfo 陣列
                PropertyInfo[] properties = type.GetProperties();
                // 迭代所有屬性
                foreach (PropertyInfo property in properties)
                {
                    if(property.PropertyType==typeof(string))
                    {
                        string value= property.GetValue(item, null)==null?string.Empty:Convert.ToString(property.GetValue(item, null));
                        if (!string.IsNullOrEmpty(value))
                        {
                            property.SetValue(item, value.Trim());
                        }
                    }
                   
                }
            }
            return list;    
        }
    }
}
