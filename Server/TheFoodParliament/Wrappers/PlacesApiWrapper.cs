using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Wrappers
{
    public class PlacesApiWrapper : IPlacesApiWrapper
    {
        public IEnumerable<Restaurant> GetRestaurantsNearby(Location location)
        {
            return new List<Restaurant>
            {
                new Restaurant("a", "Fogo de chão", "Julio de Castilhos", 1),
                new Restaurant("b","MacDonis", "Rua Sininbu", 0.3f),
                new Restaurant("c","Galeteria Galetus", "Julio de Castilhos", 1),
                new Restaurant("d","Fogo de chão II", "Julio de Castilhos", 1),
                new Restaurant("e","Espeto de Ouro", "Julio de Castilhos", 1)
            };
        }
    }
}