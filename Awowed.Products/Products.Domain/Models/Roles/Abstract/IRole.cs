using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Products.Domain.Models
{
    public interface IRole
    { 
        [JsonProperty("permissions", ItemConverterType = typeof(StringEnumConverter))]
        Permissions[] Permissions { get; }

        string ToString();
    }
}