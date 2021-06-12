using System.Collections.Generic;

namespace Products.Domain.Models
{
    public class AdminRole : IRole
    {
        public Permissions[] Permissions { get; }

        public AdminRole()
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
                Models.Permissions.Logout,
                
                Models.Permissions.ShowProductsByUser,
                Models.Permissions.ChangeUsers,
                Models.Permissions.CreateProduct,
                Models.Permissions.ChangeProduct,
                Models.Permissions.ChangeOrderStatus
            };
        }

        public override string ToString() => "Admin";
    }
}