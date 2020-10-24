using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Domain.Services;
using TheFoodParliament.Domain.Responses;

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
        public ActionResult<IEnumerable<Restaurant>> Get(float lat, float @long)
        {
            var location = new Location { Latitude = lat, Longitude = @long };
            var restaurants = _restaurantService.GetNearbyRestaurants(location);

            return Ok(restaurants);
        }
    }
}
