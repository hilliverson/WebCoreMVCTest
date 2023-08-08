using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ExtensionTool
{
    public static  class ObjectHelper
    {

        public static T TrimAllString<T>(this T obj) where T : class
        {
            
            Type type = obj.GetType();
            // 取得所有屬性的 PropertyInfo 陣列
            PropertyInfo[] properties = type.GetProperties();
            // 迭代所有屬性
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = property.GetValue(obj, null) == null ? string.Empty : Convert.ToString(property.GetValue(obj, null));
                    if (!string.IsNullOrEmpty(value))
                    {
                        property.SetValue(obj, value.Trim());
                    }
                }

            }
            return obj; 
            
        }
    }
}
