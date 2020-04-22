using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachaLib
{
    public static class Extensions
    {
        public static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        public static bool IsNullOrEmpty(this object data)
        {
            return string.IsNullOrEmpty(Convert.ToString(data));
        }
        public static int AsInt(this object data, int? defaultValue = null)
        {
            if (IsNullOrEmpty(data))
                return defaultValue != null ? Convert.ToInt32(defaultValue) : 0;

            return Convert.ToInt32(data);
        }

        public static TSource MergeObject<TSource, TTarget>(this TSource obj, TTarget obj2)
            where TSource : class
            where TTarget : class
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                try
                {
                    var propertyInfo = obj2.GetType().GetProperty(prop.Name);
                    if (propertyInfo != null)
                    {
                        var newValue = propertyInfo.GetValue(obj2, null);
                        prop.SetValue(obj, Extensions.IsNullOrEmpty(newValue) ? null : Convert.ChangeType(newValue, Extensions.IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType), null);
                    }
                }
                catch (Exception ex)
                {
                    //ex.Log();
                    //throw;
                }
            }
            return obj;
        }
    }
}
