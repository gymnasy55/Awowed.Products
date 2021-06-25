using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Domain.Models
{
    public class Order
    {
        public Guid Id { get; }
        
        public Guid UserId { get; }
        
        public List<string> ProductsIds { get; }
        
        public DateTime DateOrdered { get; }
        
        public OrderStatus OrderStatus { get; set; }

        public Order(Guid? id = null, Guid? userId = null, IEnumerable<string>? productsIds = null)
        {
            DateOrdered = DateTime.Now;
            OrderStatus = OrderStatus.New;

            Id = id ?? Guid.NewGuid();
            UserId = userId ?? Guid.NewGuid();

            ProductsIds = productsIds == null ? new List<string>() : productsIds.ToList();
        }

        public override string ToString() => 
            $"ID: {Id}\nUser ID: {UserId}\nDate Ordered: {DateOrdered:hh:mm:ss dd-MM-yyyy}\nOrder Status: {OrderStatus}\nProducts IDs:\n{string.Join("\n", ProductsIds)}";
    }
}