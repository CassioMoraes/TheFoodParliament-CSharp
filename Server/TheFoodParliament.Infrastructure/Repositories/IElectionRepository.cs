using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Infrastructure.Repositories
{
    public interface IElectionRepository
    {
        void Add(Election item);

        IEnumerable<Election> GetAllWithRestaurants();
    }
}