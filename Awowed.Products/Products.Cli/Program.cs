using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Products.Domain.Models;
using Products.Domain.Repositories;
using Products.Service.Services;

namespace Products.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileWorker = (IFileWorker) new FileWorker();
            var jsonWorker = (IJsonWorker) new JsonWorker();
            var fileName = "info.json";
            
            var repos = new ProductsRepository(fileWorker, jsonWorker);
            
            // repos.SaveProduct(new Product());
            // repos.SaveProduct(new Product());
            // repos.SaveProduct(new Product());
            // repos.SaveProduct(new Product());
            // repos.SaveProduct(new Product());
            //
            // repos.SaveToFile(fileName);

            repos.LoadFromFile(fileName);
            
            var products = repos.GetAllProducts().Values;
            
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}