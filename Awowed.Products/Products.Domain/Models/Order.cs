using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Products.Domain.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public Guid Id { get; }
        
        [JsonProperty("user_id")]
        public Guid UserId { get; }
        
        [JsonProperty("products_ids")]
        public List<string> ProductsIds { get; }
        
        [JsonProperty("date_ordered")]
        [JsonConverter(typeof(JavaScriptDateTimeConverter))]
        public DateTime DateOrdered { get; }
        
        [JsonProperty("order_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }

        public Order(Guid? userId = null, Guid? id = null, IEnumerable<string>? productsIds = null)
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