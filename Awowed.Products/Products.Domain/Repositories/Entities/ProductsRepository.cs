using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using Products.Domain.Models;

namespace Products.Domain.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
        
        private readonly Dictionary<Guid, Product> _products;

        //TODO: Encapsulate to other class
        private static Stream GenerateStream(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        
        public ProductsRepository()
        {
            _products = new Dictionary<Guid, Product>();
            for (var i = 0; i < 5; i++)
            {
                var product = new Product();
                SaveProduct(product);
            }
        }
        
        public async void ReadAsync(string? fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            using (var reader = File.OpenText(fileName))
            {
                var json = await reader.ReadToEndAsync();
                using (var stream = GenerateStream(json))
                {
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(stream);
                    if (products == null)
                        throw new NullReferenceException($"{nameof(products)} is null");   
                    
                    foreach (var product in products)
                        SaveProduct(product);
                }
            }
        }

        public void Read(string? fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            using (var reader = File.OpenText(fileName))
            {
                var json = reader.ReadToEnd();
                var products = JsonSerializer.Deserialize<List<Product>>(json);
                if (products == null)
                    throw new NullReferenceException($"{nameof(products)} is null");   
                    
                foreach (var product in products)
                    SaveProduct(product);
            }
        }

        public void Write(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                var json = JsonSerializer.Serialize<IEnumerable<Product>>(_products.Values, _options);
                writer.Write(json);
            }
        }

        public Dictionary<Guid, Product> GetAllProducts() => _products;

        public Product GetProductById(Guid id) => _products[id];
        public Product GetProductById(string id) => GetProductById(Guid.Parse(id));

        public void SaveProduct(Product product) => _products.Add(product.Id, product);
    }
}