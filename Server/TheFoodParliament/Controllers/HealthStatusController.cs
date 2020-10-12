using Microsoft.AspNetCore.Mvc;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthStatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Up and running");
        }
    }
}