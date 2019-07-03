using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace JsonClient.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue) =>
            enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()
                ?.Name
            ?? enumValue.ToString();
    }
}
