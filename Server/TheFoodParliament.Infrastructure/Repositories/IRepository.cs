using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Infrastructure.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(int id);
    }
}