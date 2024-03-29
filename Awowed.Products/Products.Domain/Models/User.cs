﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Products.Domain.Models
{
    public class User
    {
        [JsonProperty("id")]
        public Guid Id { get; }
        
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Roles Role { get; set; }
        
        [JsonProperty("login")]
        public string Login { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

        public User(Guid? id = null, Roles? role = null, string? login = null, string? password = null)
        {
            Id = id ?? Guid.NewGuid();
            Role = role ?? Roles.Guest;
            Login = login ?? "Default Login";
            Password = password ?? "Default Password";
        }

        public override string ToString() =>
            $"ID: {Id}\nRole: {PermissionsManager.GetName(Role)}\nLogin: {Login}\nPassword: {Password}";
    }
}