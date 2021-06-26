using System;
using System.Collections.Generic;
using System.IO;
using Products.Domain.Models;
using Products.Service;
using Products.Service.Services;
using AppContext = Products.Domain.Models.AppContext;

namespace Products.Domain.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IFileService _fileService;
        private readonly IJsonService _jsonService;
        private readonly IDictionary<Guid, Order> _orders;

        public OrdersRepository(AppContext context, ServiceManager manager)
        {
            _fileService = manager.FileService;
            _jsonService = manager.JsonService;
            _orders = context.Orders;
        }

        public void LoadFromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} cannot be null");
            
            if (!File.Exists(fileName)) 
                throw new ArgumentException("File does not exists!");

            var orders = _jsonService.Deserialize<IEnumerable<Order>>(_fileService.Read(fileName));

            foreach (var order in orders)
                Save(order);
        }

        public void SaveToFile(string fileName) => _fileService.Write(fileName, _jsonService.Serialize(_orders.Values));

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