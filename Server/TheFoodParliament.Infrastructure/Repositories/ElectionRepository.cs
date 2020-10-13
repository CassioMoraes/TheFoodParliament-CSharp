using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Context;

namespace TheFoodParliament.Infrastructure.Repositories
{
    public class ElectionRepository : GenericRepository<Election>, IElectionRepository
    {
        private ParliamentContext _context;
        private DbSet<Election> _entities;

        public ElectionRepository(ParliamentContext context)
            : base(context)
        {
            this._context = context;
            _entities = context.Set<Election>();
        }
        public IEnumerable<Election> GetAllWithRestaurants()
        {
            return _entities.Include(e => e.Restaurant).ToList();
        }
    }
}