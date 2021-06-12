using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Products.Domain.Models
{
    public class Order
    {
        [JsonPropertyName("id")]
        public Guid Id { get; }
        
        [JsonPropertyName("user_id")]
        public Guid UserId { get; }
        
        [JsonPropertyName("products_ids")]
        public List<string> ProductsIds { get; }
        
        [JsonPropertyName("date_ordered")]
        public DateTime DateOrdered { get; }
        
        [JsonPropertyName("order_status")]
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