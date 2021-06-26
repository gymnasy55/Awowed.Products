using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service.Services;

namespace Products.Domain.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IFileWorker _fileWorker;
        private readonly IJsonWorker _jsonWorker;
        private readonly IDictionary<Guid, Product> _products;

        public ProductsRepository(IFileWorker fileWorker, IJsonWorker jsonWorker)
        {
            _fileWorker = fileWorker;
            _jsonWorker = jsonWorker;
            _products = new Dictionary<Guid, Product>();
        }
        
        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var products = _jsonWorker.Deserialize<IEnumerable<Product>>(_fileWorker.Read(fileName));

            foreach (var product in products)
                Save(product);
        }

        public void SaveToFile(string fileName) => _fileWorker.Write(fileName, _jsonWorker.Serialize(_products.Values));
    
        public IDictionary<Guid, Product> GetAll() => _products;
    
        public Product GetById(Guid id) => _products[id];
        public Product GetById(string id) => GetById(Guid.Parse(id));
    
        public void Save(Product product)
        {
            if (_products.ContainsKey(product.Id))
            {
                _products[product.Id] = product;
                return;
            }
            
            _products.Add(product.Id, product);
        }
    }
}