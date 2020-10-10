using Microsoft.AspNetCore.Mvc;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthStatusController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Up and running";
        }
    }
}