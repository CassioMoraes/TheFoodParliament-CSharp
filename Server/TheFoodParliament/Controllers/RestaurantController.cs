using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Services;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(ILogger<RestaurantController> logger,
            IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get(float lat, float @long)
        {
            var location = new Location { Latitude = lat, Longitude = @long };
            return _restaurantService.GetNearbyRestaurants(location);
        }
    }
}
