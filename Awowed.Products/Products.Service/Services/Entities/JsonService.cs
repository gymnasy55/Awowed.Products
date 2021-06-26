using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products.Service.Services
{
    public class JsonService : IJsonService
    {
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);

        T IJsonService.Deserialize<T>(string json) => Deserialize<T>(json);
        string IJsonService.Serialize<T>(T obj) => Serialize<T>(obj);
    }
}