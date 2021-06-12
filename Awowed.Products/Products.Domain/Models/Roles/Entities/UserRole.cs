using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class UserRole : IRole
    {
        public Permissions[] Permissions { get; }

        public UserRole()
        {
            Permissions = new[]
            {
                Models.Permissions.ViewProduct,
                Models.Permissions.SearchProductsByName,
                Models.Permissions.ReceiveOrderStatus,
                Models.Permissions.CreateOrder,
                Models.Permissions.PlaceOrder,
                Models.Permissions.CancelOrder,
                Models.Permissions.ChangeOwnInfo,
                Models.Permissions.Logout
            };
        }
        
        public override string ToString() => "User";
    }
}