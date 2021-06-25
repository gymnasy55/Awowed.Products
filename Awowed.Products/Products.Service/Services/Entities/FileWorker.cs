using System;
using System.IO;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class FileWorker : IFileWorker
    {
        public static string Read(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            using var reader = File.OpenText(fileName);
            return reader.ReadToEnd();
        }

        public static void Write(string fileName, string text)
        {
            using var writer = new StreamWriter(fileName);
            writer.Write(text);
        }

        string IFileWorker.Read(string fileName) => Read(fileName);
        void IFileWorker.Write(string fileName, string text) => Write(fileName, text);
    }
}