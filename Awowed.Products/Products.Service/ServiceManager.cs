using Products.Service.Services;

namespace Products.Service
{
    public class ServiceManager
    {
        public IFileService FileService { get; }
        public IJsonService JsonService { get; }

        public ServiceManager()
        {
            FileService = new FileService();
            JsonService = new JsonService();
        }
    }
}