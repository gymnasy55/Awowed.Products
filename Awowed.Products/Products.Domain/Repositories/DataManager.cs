using Products.Domain.Models;
using Products.Service;

namespace Products.Domain.Repositories
{
    public class DataManager
    {
        public IUsersRepository Users { get; }
        public IProductsRepository Products { get; }
        public IOrdersRepository Orders { get; }

        public DataManager(AppContext context, ServiceManager manager)
        {
            Users = new UsersRepository(context, manager);
            Products = new ProductsRepository(context, manager);
            Orders = new OrdersRepository(context, manager);
        }
    }
}