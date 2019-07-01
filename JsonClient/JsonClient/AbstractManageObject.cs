using System;
using JsonClient.Attributes;
namespace JsonClient
{
  public abstract class AbstractManageObject
  {
    public override string ToString()
    {
      string ObjectString= "";
      Type t = this.GetType();
                var properties =t.GetProperties();
                foreach(var pi in properties)
                {
                    if(Attribute.IsDefined(pi,typeof(IsClassAttribute)))
                      pi.GetValue(this).ToString();
                    else
                     ObjectString+=(($"{pi.GetDisplayName()}: {pi.GetValue(this)}\n\n"));   
                }
                return ObjectString;
    }
  
    
  }
}
