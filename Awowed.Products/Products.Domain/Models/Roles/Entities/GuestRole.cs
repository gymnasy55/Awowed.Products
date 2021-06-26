using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class GuestRole : IRole
    {
        public static Permissions[] Permissions { get; }

        static GuestRole()
        {
            Permissions = new[]
            {
                Models.Permissions.Register,
                Models.Permissions.ViewProduct,
                Models.Permissions.SearchProductsByName,
                Models.Permissions.Login
            };
        }
        
        public new static string ToString() => "Guest";

        Permissions[] IRole.Permissions => Permissions;
        string IRole.ToString() => ToString();
    }
}