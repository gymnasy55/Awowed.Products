using System;
using Products.Application.View;
using Products.Domain.Models;
using Products.Domain.Repositories;

namespace Products.Application.Controllers
{
    public class MainController
    {
        private readonly IView _view;
        private readonly DataManager _dataManager;

        public MainController(IView view, DataManager dataManager)
        {
            _view = view;
            _dataManager = dataManager;
        }

        public void Start()
        {
            var accountController = new AccountController(_view, _dataManager);
            var user = accountController.Start();
            Console.WriteLine(user);
        }
    }
}