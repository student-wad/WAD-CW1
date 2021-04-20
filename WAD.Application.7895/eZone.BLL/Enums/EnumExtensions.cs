using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eZone.BLL.Enums
{
   public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
               where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
        public static List<EnumValue> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<Enum>().Select(v => new EnumValue()
            {
                Name = v.GetAttribute<DisplayAttribute>().Name,
                Value = Convert.ToInt32(v)
            }).ToList();
        }

    }
}
