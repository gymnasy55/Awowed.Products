using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class UserRole : IRole
    {
        public static Permissions[] Permissions { get; }

        static UserRole()
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
        
        public new static string ToString() => "User";

        Permissions[] IRole.Permissions => Permissions;
        string IRole.ToString() => ToString();
    }
}