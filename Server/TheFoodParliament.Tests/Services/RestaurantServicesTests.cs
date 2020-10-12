using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Services;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Tests
{
    public class RestaurantServiceTests
    {
        private Mock<IPlacesApiWrapper> _placesApiWrapperMock;
        private Mock<IRepository<Restaurant>> _restaurantRepositoryMock;

        [OneTimeSetUp]
        public void TestSetup()
        {
            var defaultPlacesList = new List<Restaurant>
            {
                new Restaurant("a", "Fogo de chão", "Julio de Castilhos", 1),
                new Restaurant("b","MacDonis", "Rua Sininbu", 0.3f),
                new Restaurant("c","Galeteria Galetus", "Julio de Castilhos", 1),
                new Restaurant("d","Fogo de chão II", "Julio de Castilhos", 1),
                new Restaurant("e","Espeto de Ouro", "Julio de Castilhos", 1)
            };

            _placesApiWrapperMock = new Mock<IPlacesApiWrapper>();
            _placesApiWrapperMock.Setup(m => m.GetRestaurantsNearby(It.IsAny<Location>())).Returns(defaultPlacesList);

            _restaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
        }

        [TestCase(10, 10)]
        public void GetNearbyRestaurants_PassingLocation_ShouldReturn5Restaurants(float latitude, float longitude)
        {

            var location = new Location { Latitude = latitude, Longitude = longitude };
            var restaurantService = new RestaurantService(_placesApiWrapperMock.Object, _restaurantRepositoryMock.Object);
            var nearbyRestaurants = restaurantService.GetNearbyRestaurants(location).ToList();

            Assert.AreEqual(5, nearbyRestaurants.Count);
        }
    }
}