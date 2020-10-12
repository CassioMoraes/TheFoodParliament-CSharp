using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Wrappers
{
    public interface IPlacesApiWrapper
    {
        IEnumerable<Restaurant> GetRestaurantsNearby(Location location);
    }
}