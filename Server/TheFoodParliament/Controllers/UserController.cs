using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Domain.Services;
using TheFoodParliament.Domain.Responses;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
    }
}