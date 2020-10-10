using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrasctucture.Context;

namespace TheFoodParliament.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private ParliamentContext _context;
        private DbSet<T> _entities;

        public GenericRepository(ParliamentContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }
        
        public void Add(T item)
        {
            _entities.Add(item);
            _context.SaveChanges();
        }
        
        public T GetById(int id)
        {
            return _entities.Find(id);
        }
        
        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }
        
        public void Update(T item)
        {
            _entities.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var existing = _entities.Find(id);
            _context.Remove(existing);
            _context.SaveChanges();
        }
    }
}