namespace Products.Service.Services
{
    public interface IJsonService
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T obj);
    }
}