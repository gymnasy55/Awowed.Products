using System;
using System.Text.Json.Serialization;

namespace Products.Domain.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public Guid Id { get; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("price")]
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

        public override string ToString() => 
            $"ID: {Id}\nName: {Name}\nCategory: {Category}\nDescription: {Description}\nPrice: {Price} UAH";
    }
}