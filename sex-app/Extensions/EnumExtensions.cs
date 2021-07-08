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
    }
}