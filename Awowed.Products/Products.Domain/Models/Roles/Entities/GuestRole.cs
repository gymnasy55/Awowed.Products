using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class GuestRole : IRole
    {
        public Permissions[] Permissions { get; }

        public GuestRole()
        {
            Permissions = new[]
            {
                Models.Permissions.Register,
                Models.Permissions.ViewProduct,
                Models.Permissions.SearchProductsByName,
                Models.Permissions.Login
            };
        }
        
        public override string ToString() => "Guest";
    }
}