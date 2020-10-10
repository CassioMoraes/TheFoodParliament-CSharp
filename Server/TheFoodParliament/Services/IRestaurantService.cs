using System.Collections.Generic;
using TheFoodParliament.Models;

namespace TheFoodParliament.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetNearbyRestaurants(Location location);
    }
}