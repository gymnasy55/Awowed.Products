using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products.Service.Services
{
    public class JsonWorker : IJsonWorker
    {
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj);

        T IJsonWorker.Deserialize<T>(string json) => Deserialize<T>(json);
        string IJsonWorker.Serialize<T>(T obj) => Serialize<T>(obj);
    }
}