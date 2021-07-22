using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace sex_app.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue, string c = null)
        {
            return
                $"{c}{enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName()}{c}";
        }

        public static string GetValueByDisplay(string display, Type type)
        {
            return $"{type.GetMembers().Where(x => x.GetCustomAttribute<DisplayAttribute>()?.GetName() == display)}";
        }
        
        public static string GetDisplayName(this object enumValue, string c = null)
        {
            return
                $"{c}{enumValue.GetType().GetMember(enumValue.ToString() ?? string.Empty).First().GetCustomAttribute<DisplayAttribute>()?.GetName()}{c}";
        }
    }
}