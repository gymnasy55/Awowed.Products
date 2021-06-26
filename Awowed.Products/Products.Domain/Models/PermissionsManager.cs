using System;

namespace Products.Domain.Models
{
    public static class PermissionsManager
    {
        public static string GetName(Roles role) =>
            role switch {
                Roles.Guest => "Guest",
                Roles.User => "User",
                Roles.Admin => "Admin",
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        
        public static Permissions[] GetPermissions(Roles role) =>
            role switch
            {
                Roles.Guest => new []
                {
                    Permissions.Register,
                    Permissions.ViewProduct,
                    Permissions.SearchProductsByName,
                    Permissions.Login
                },
                Roles.User => new []
                {
                    Permissions.ViewProduct,
                    Permissions.SearchProductsByName,
                    Permissions.ReceiveOrderStatus,
                    Permissions.CreateOrder,
                    Permissions.PlaceOrder,
                    Permissions.CancelOrder,
                    Permissions.ChangeOwnInfo,
                    Permissions.Logout 
                },
                Roles.Admin => new []
                {
                    Permissions.ViewProduct,
                    Permissions.SearchProductsByName,
                    Permissions.ReceiveOrderStatus,
                    Permissions.CreateOrder,
                    Permissions.PlaceOrder,
                    Permissions.CancelOrder,
                    Permissions.ChangeOwnInfo,
                    Permissions.Logout, 
                    Permissions.ShowProductsByUser,
                    Permissions.ChangeUsers,
                    Permissions.CreateProduct,
                    Permissions.ChangeProduct,
                    Permissions.ChangeOrderStatus
                },
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
    }
}