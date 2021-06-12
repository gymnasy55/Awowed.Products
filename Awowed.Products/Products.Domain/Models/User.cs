using System;

namespace Products.Domain.Models
{
    public class User
    {
        public Guid Id { get; }
        public IRole Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
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