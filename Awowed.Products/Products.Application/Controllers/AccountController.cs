using System;
using Products.Application.View;
using Products.Domain.Models;
using Products.Domain.Repositories;

namespace Products.Application.Controllers
{
    public class AccountController
    {
        private readonly IView _view;
        private readonly IUsersRepository _users;

        public AccountController(IView view, DataManager dataManager)
        {
            _view = view;
            _users = dataManager.Users;
            _users.LoadFromFile("users.json");
        }

        public User Start() =>
            _view.ShowMainMenu() switch
            {
                1 => Register(),
                2 => Authorize(),
                3 => new User(),
                _ => throw new ArgumentOutOfRangeException()
            };

        private User Authorize()
        {
            var (login, password) = _view.ShowAuthorization();
            var user = _users.GetByLoginAndPassword(login, password);
            if (user != null) return user;
            _view.ShowMessage("Login or password is incorrect!");
            return Authorize();
        }

        private User Register()
        {
            var (login, password) = _view.ShowRegistration();
            if (_users.GetByLogin(login) != null)
            {
                _view.ShowMessage($"User with login \"{login}\" already exists!");
                return Register();
            }
            var user = new User
            {
                Role = Roles.User,
                Login = login,
                Password = password
            };
            _users.Save(user);
            return Start();
        }
    }
}