using System;
using Products.Application.Controllers;
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
            var console = new ConsoleView();

            var context = new AppContext();
            var serviceManager = new ServiceManager();
            var dataManager = new DataManager(context, serviceManager);

            var controller = new MainController(console, dataManager);
            
            controller.Start();

            // var prodFileName = "products.json";
            // var ordersFileName = "orders.json";
            // var usersFileName = "users.json";
        }
    }
}