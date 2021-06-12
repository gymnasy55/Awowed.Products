using System;
using System.Collections.Generic;
using Products.Domain.Models;

namespace Products.Domain.Repositories
{
    public interface IProductsRepository
    {
        void ReadAsync(string? fileName);
        
        void Read(string? fileName);
        Dictionary<Guid, Product> GetAllProducts();
        Product GetProductById(Guid id);
        Product GetProductById(string id);
        void SaveProduct(Product product);
    }
}