using System.Linq;
using NUnit.Framework;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Services;

namespace TheFoodParliament.Tests
{
    public class RestaurantServiceTests
    {
        [TestCase(10, 10)]
        public void GetNearbyRestaurants_PassingLocation_ShouldReturn5Restaurants(float latitude, float longitude)
        {
            var location = new Location { Latitude = latitude, Longitude = longitude };
            var restaurantService = new RestaurantService();
            var nearbyRestaurants = restaurantService.GetNearbyRestaurants(location).ToList();

            Assert.AreEqual(5, nearbyRestaurants.Count);
        }
    }
}