using System;
using JsonClient.Attributes;
namespace JsonClient
{
  public abstract class AbstractManageObject
  {
    public override string ToString()
    {
      string objectString= "";
      Type t = this.GetType();
                var properties =t.GetProperties();
                foreach(var pi in properties)
                {
                    if(Attribute.IsDefined(pi,typeof(IsClassAttribute)))
                      objectString += pi.GetValue(this).ToString();
                    else
                     objectString +=(($"{pi.GetDisplayName()}: {pi.GetValue(this)}\n\n"));
                }
                return objectString;
    }
  
    
  }
}
