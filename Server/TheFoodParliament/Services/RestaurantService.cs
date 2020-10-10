using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Services
{
    public class RestaurantService : IRestaurantService
    {
        public IEnumerable<Restaurant> GetNearbyRestaurants(Location location)
        {
            return new List<Restaurant>
            {
                new Restaurant("Fogo de chão", "Julio de Castilhos", 1),
                new Restaurant("MacDonis", "Rua Sininbu", 0.3f),
                new Restaurant("Galeteria Galetus", "Julio de Castilhos", 1),
                new Restaurant("Fogo de chão II", "Julio de Castilhos", 1),
                new Restaurant("Espeto de Ouro", "Julio de Castilhos", 1)
            };
        }
    }
}