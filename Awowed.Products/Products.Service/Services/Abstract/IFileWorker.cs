using System.Threading.Tasks;

namespace Products.Service.Services
{
    public interface IFileWorker
    {
        string Read(string fileName);
        
        void Write(string fileName, string text);
    }
}