using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service;
using Products.Service.Services;
using AppContext = Products.Domain.Models.AppContext;

namespace Products.Domain.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IFileService _fileService;
        private readonly IJsonService _jsonService;
        private readonly IDictionary<Guid, User> _users;

        public UsersRepository(AppContext context, ServiceManager manager)
        {
            _fileService = manager.FileService;
            _jsonService = manager.JsonService;
            _users = context.Users;
        }
        
        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var users = _jsonService.Deserialize<IEnumerable<User>>(_fileService.Read(fileName));

            foreach (var user in users)
                Save(user);
        }

        public void SaveToFile(string fileName) => _fileService.Write(fileName, _jsonService.Serialize(_users.Values));

        public IDictionary<Guid, User> GetAll() => _users;

        public User GetById(Guid id) => _users[id];

        public User GetById(string id) => GetById(Guid.Parse(id));

        public void Save(User user)
        {
            if (_users.ContainsKey(user.Id))
            {
                _users[user.Id] = user;
                return;
            }
            
            _users.Add(user.Id, user);
        }
    }
}