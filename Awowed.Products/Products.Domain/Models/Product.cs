using System;
using Newtonsoft.Json;

namespace Products.Domain.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public Guid Id { get; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("price")]
        public decimal Price { get; set; }
        
        public Product(Guid? id = null, string? name = null, string? category = null, string? description = null,
            decimal? price = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name ?? "Default Name";
            Category = category ?? "Default Category";
            Description = description ?? "Default Description";
            Price = price ?? 0;
        }
        
        private Product(string id, string name, string category, string description,
            decimal price)
        {
            Id = Guid.Parse(id);
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
        
        public override string ToString() => 
            $"ID: {Id}\nName: {Name}\nCategory: {Category}\nDescription: {Description}\nPrice: {Price} UAH";
    }
}