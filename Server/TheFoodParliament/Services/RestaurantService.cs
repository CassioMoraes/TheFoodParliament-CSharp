using System.Collections.Generic;
using System.Linq;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IPlacesApiWrapper _placesApiWrapper;
        private IRepository<Restaurant> _restaurantRepository;

        public RestaurantService(IPlacesApiWrapper placesApiWrapper,
            IRepository<Restaurant> restaurantRepository)
        {
            _placesApiWrapper = placesApiWrapper;
            _restaurantRepository = restaurantRepository;
        }

        public IEnumerable<Restaurant> GetNearbyRestaurants(Location location)
        {
            var restaurants = _placesApiWrapper.GetRestaurantsNearby(location);
            var currentRestaurants = _restaurantRepository.GetAll();

            var newRestaurants = restaurants
                .Where(r => currentRestaurants
                    .FirstOrDefault(cr => cr.PlacesApiId == r.PlacesApiId) == null);

            foreach (var newRestaurant in newRestaurants)
                _restaurantRepository.Add(newRestaurant);

            return restaurants;
        }
    }
}