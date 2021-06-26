using System;
using System.Collections.Generic;

namespace Products.Domain.Repositories
{
    public interface IRepository<T>
    {
        void LoadFromFile(string fileName);
        void SaveToFile(string fileName);
        IDictionary<Guid, T> GetAll();
        T GetById(Guid id);
        T GetById(string id);
        void Save(T obj);
    }
}