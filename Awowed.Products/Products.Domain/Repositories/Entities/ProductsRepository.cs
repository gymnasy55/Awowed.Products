using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service;
using Products.Service.Services;
using AppContext = Products.Domain.Models.AppContext;

namespace Products.Domain.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IFileService _fileService;
        private readonly IJsonService _jsonService;
        private readonly IDictionary<Guid, Product> _products;

        public ProductsRepository(AppContext context, ServiceManager manager)
        {
            _fileService = manager.FileService;
            _jsonService = manager.JsonService;
            _products = context.Products;
        }
        
        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var products = _jsonService.Deserialize<IEnumerable<Product>>(_fileService.Read(fileName));

            foreach (var product in products)
                Save(product);
        }

        public void SaveToFile(string fileName) => _fileService.Write(fileName, _jsonService.Serialize(_products.Values));
    
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