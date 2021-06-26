using Products.Domain.Models;

namespace Products.Domain.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        User? GetByLogin(string login);
        User? GetByLoginAndPassword(string login, string password);
    }
}