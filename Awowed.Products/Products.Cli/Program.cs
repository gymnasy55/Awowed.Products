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
            var prodFileName = "products.json";
            var ordersFileName = "orders.json";
            var usersFileName = "users.json";

            #region Products

            // var prodRepos = new ProductsRepository(fileWorker, jsonWorker);
            //
            // prodRepos.Save(new Product());
            // prodRepos.Save(new Product());
            // prodRepos.Save(new Product());
            // prodRepos.Save(new Product());
            // prodRepos.Save(new Product());
            //
            // prodRepos.SaveToFile(prodFileName);
            //
            // prodRepos.LoadFromFile(prodFileName);
            //
            // var products = prodRepos.GetAll().Values;
            //
            // foreach (var product in products)
            // {
            //     Console.WriteLine(product);
            // }

            #endregion

            #region Orders

            //var ordersRepos = new OrdersRepository(fileWorker, jsonWorker);
            //
            // ordersRepos.Save(new Order());
            // ordersRepos.Save(new Order());
            // ordersRepos.Save(new Order());
            // ordersRepos.Save(new Order());
            // ordersRepos.Save(new Order());
            // ordersRepos.SaveToFile(ordersFileName);
            //
            // ordersRepos.LoadFromFile(ordersFileName);
            //
            // var orders = ordersRepos.GetAll().Values;
            // foreach (var order in orders)
            // {
            //     Console.WriteLine(order);
            // }

            #endregion

            #region Users

            var usersRepos = new UsersRepository(fileWorker, jsonWorker);
            
            usersRepos.Save(new User());
            usersRepos.Save(new User());
            usersRepos.Save(new User());
            usersRepos.Save(new User());
            usersRepos.Save(new User());
            
            usersRepos.SaveToFile(usersFileName);
            #endregion
        }
    }
}