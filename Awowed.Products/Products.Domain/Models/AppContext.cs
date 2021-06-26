using System;
using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class AppContext
    {
        public IDictionary<Guid, Product> Products { get; set; }
        public IDictionary<Guid, Order> Orders { get; set; }
        public IDictionary<Guid, User> Users { get; set; }

        public AppContext()
        {
            Products = new Dictionary<Guid, Product>();
            Orders = new Dictionary<Guid, Order>();
            Users = new Dictionary<Guid, User>();
        }
    }
}