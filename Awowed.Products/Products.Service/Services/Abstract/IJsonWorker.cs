namespace Products.Service.Services
{
    public interface IJsonWorker
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T obj);
    }
}