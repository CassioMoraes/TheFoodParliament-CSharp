using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetNearbyRestaurants(Location location);
    }
}