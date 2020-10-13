using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Infrastructure.Repositories
{
    public interface IElectionRepository
    {
        IEnumerable<Election> GetAllWithRestaurants();
    }
}