using System.Collections.Generic;
using System.Linq;
using TheFoodParliament.Domain.Wrappers;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;

namespace TheFoodParliament.Domain.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IPlacesApiWrapper _placesApiWrapper;
        private readonly IRepository<Restaurant> _restaurantRepository;

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

            var nearbyRestaurants = _restaurantRepository.GetAll().Where(r => restaurants.Any(pr => pr.PlacesApiId == r.PlacesApiId));

            return nearbyRestaurants;
        }
    }
}