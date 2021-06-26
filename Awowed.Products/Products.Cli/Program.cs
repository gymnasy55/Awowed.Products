using System;
using Products.Domain.Models;
using Products.Domain.Repositories;
using Products.Service;
using AppContext = Products.Domain.Models.AppContext;

namespace Products.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var appContext = new AppContext();
            var serviceManager = new ServiceManager();

            var prodFileName = "products.json";
            var ordersFileName = "orders.json";
            var usersFileName = "users.json";

            #region Products

            var prodRepos = new ProductsRepository(appContext, serviceManager);
            
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
            //     Console.WriteLine(product);

            #endregion

            #region Orders

            var ordersRepos = new OrdersRepository(appContext, serviceManager);
            
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
            //     Console.WriteLine(order);

            #endregion

            #region Users

            var usersRepos = new UsersRepository(appContext, serviceManager);
            
            usersRepos.Save(new User { Role = Roles.Admin });
            usersRepos.Save(new User());
            usersRepos.Save(new User { Role = Roles.User });
            usersRepos.Save(new User());
            usersRepos.Save(new User());
            
            usersRepos.SaveToFile(usersFileName);
            //
            // usersRepos.LoadFromFile(usersFileName);
            //
            // var users = usersRepos.GetAll().Values;
            // foreach (var user in users)
            //     Console.WriteLine(user);

            #endregion
        }
    }
}