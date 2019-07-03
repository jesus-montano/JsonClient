using System;
using System.Text;
using JsonClient.Attributes;

namespace JsonClient
{
    public abstract class EntityBase
    {
        public override string ToString()
        {
            var builder = new StringBuilder();
            Type t = this.GetType();
            var properties = t.GetProperties();
            foreach (var pi in properties)
            {
                if (Attribute.IsDefined(pi, typeof(IsClassAttribute)))
                    builder.AppendLine(pi.GetValue(this).ToString());
                else
                    builder.AppendLine(($"{pi.GetDisplayName()}: {pi.GetValue(this)}\n"));
            }
            return builder.ToString();
        }
    }
}