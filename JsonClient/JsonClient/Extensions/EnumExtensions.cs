using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using JsonClient.Attributes;

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

            public static bool GetSkip(this Enum enumValue){
              var memberInfo =  enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
                return Attribute.IsDefined(memberInfo, typeof(SkipAttribute));
                
            }
                
            
    }
    

    
}
