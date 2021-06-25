using System;
using System.Collections.Generic;
using Products.Domain.Models;

namespace Products.Domain.Repositories
{
    public interface IProductsRepository
    {
        void LoadFromFile(string fileName);
        void SaveToFile(string fileName);
        IDictionary<Guid, Product> GetAllProducts();
        Product GetProductById(Guid id);
        Product GetProductById(string id);
        void SaveProduct(Product product);
    }
}