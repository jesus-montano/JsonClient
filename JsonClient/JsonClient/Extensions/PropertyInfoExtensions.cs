using System;
using System.ComponentModel.DataAnnotations;
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
 }
}