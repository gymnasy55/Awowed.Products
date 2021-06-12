using System;
using System.Collections.Generic;
using Products.Domain.Models;
using Products.Domain.Repositories;

namespace Products.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // var role1 = new GuestRole();
            // Console.WriteLine(string.Join(" ", role1.Permissions));
            //
            // var role2 = new UserRole();
            // Console.WriteLine(string.Join(" ", role2.Permissions));
            //
            // var role3 = new AdminRole();
            // Console.WriteLine(string.Join(" ", role3.Permissions));

            var repos = new ProductsRepository();
            repos.SaveProduct(new Product());
            repos.SaveProduct(new Product());
            repos.SaveProduct(new Product());
            repos.SaveProduct(new Product());
            repos.SaveProduct(new Product());
            
            repos.Write("info.json");
        }
    }
}