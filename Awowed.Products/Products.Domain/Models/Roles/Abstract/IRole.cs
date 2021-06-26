using Newtonsoft.Json;

namespace Products.Domain.Models
{
    public interface IRole
    { 
        [JsonProperty("permissions")]
        Permissions[] Permissions { get; }
        
        string ToString();
    }
}