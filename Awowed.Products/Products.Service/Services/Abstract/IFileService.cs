namespace Products.Service.Services
{
    public interface IFileService
    {
        string Read(string fileName);
        
        void Write(string fileName, string text);
    }
}