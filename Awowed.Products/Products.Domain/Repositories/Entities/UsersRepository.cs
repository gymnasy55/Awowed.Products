using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service.Services;

namespace Products.Domain.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IFileWorker _fileWorker;
        private readonly IJsonWorker _jsonWorker;
        private readonly IDictionary<Guid, User> _users;

        public UsersRepository(IFileWorker fileWorker, IJsonWorker jsonWorker)
        {
            _fileWorker = fileWorker;
            _jsonWorker = jsonWorker;
            _users = new Dictionary<Guid, User>();
        }
        
        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var users = _jsonWorker.Deserialize<IEnumerable<User>>(_fileWorker.Read(fileName));

            foreach (var user in users)
                Save(user);
        }

        public void SaveToFile(string fileName) => _fileWorker.Write(fileName, _jsonWorker.Serialize(_users.Values));

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