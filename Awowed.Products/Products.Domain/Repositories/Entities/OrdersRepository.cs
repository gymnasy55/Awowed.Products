using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service.Services;

namespace Products.Domain.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IFileWorker _fileWorker;
        private readonly IJsonWorker _jsonWorker;
        private readonly IDictionary<Guid, Order> _orders;


        public OrdersRepository(IFileWorker fileWorker, IJsonWorker jsonWorker)
        {
            _fileWorker = fileWorker;
            _jsonWorker = jsonWorker;
            _orders = new Dictionary<Guid, Order>();
        }

        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var orders = _jsonWorker.Deserialize<IEnumerable<Order>>(_fileWorker.Read(fileName));

            foreach (var order in orders)
                Save(order);
        }

        public void SaveToFile(string fileName) => _fileWorker.Write(fileName, _jsonWorker.Serialize(_orders.Values));

        public IDictionary<Guid, Order> GetAll() => _orders;

        public Order GetById(Guid id) => _orders[id];

        public Order GetById(string id) => _orders[Guid.Parse(id)];

        public void Save(Order order)
        {
            if (_orders.ContainsKey(order.Id))
            {
                _orders[order.Id] = order;
                return;
            }
            
            _orders.Add(order.Id, order);
        }
    }
}