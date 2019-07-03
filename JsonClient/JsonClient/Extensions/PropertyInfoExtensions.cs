using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
namespace JsonClient
{
 public static class PropertyInfoExtensions
 {
    public static string GetDisplayName(this PropertyInfo pi){
            if(Attribute.IsDefined(pi,typeof(DisplayAttribute)))
            {                
                var attribute =pi.GetCustomAttribute(typeof(DisplayAttribute)); 
                return (attribute as DisplayAttribute).Name;
            }
            else            
                return pi.Name;
    }
    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field.GetCustomAttributes(typeof(DescriptionAttribute),false);
        return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;        
    }
 }
}