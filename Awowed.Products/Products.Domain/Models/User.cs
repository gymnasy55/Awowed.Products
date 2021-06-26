using System;
using Newtonsoft.Json;

namespace Products.Domain.Models
{
    public class User
    {
        [JsonProperty("id")]
        public Guid Id { get; }
        
        [JsonProperty("role")]
        public IRole Role { get; set; }
        
        [JsonProperty("login")]
        public string Login { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("info")]
        public string Info { get; set; }

        public User(Guid? id = null, IRole? role = null, string? login = null, string? password = null,
            string? info = null)
        {
            Id = id ?? Guid.NewGuid();
            Role = role ?? new GuestRole();
            Login = login ?? "Default Login";
            Password = password ?? "Default Password";
            Info = info ?? "Default Info";
        }

        public override string ToString() =>
            $"ID: {Id}\nRole: {Role}\nLogin: {Login}\nPassword: {Password}\nInfo: {Info}";
    }
}