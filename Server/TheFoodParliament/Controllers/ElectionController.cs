using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Domain.Services;
using TheFoodParliament.Domain.Responses;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectionController : ControllerBase
    {
        private readonly ILogger<ElectionController> _logger;
        private readonly IElectionService _electionService;

        public ElectionController(ILogger<ElectionController> logger,
            IElectionService electionService)
        {
            _logger = logger;
            _electionService = electionService;
        }

        [HttpGet]
        [Route("last-winner")]
        public IActionResult GetLastWinner()
        {
            var winner = _electionService.GetLastWinner();
            return Ok(winner);
        }

        [HttpGet]
        [Route("compute-result")]
        public IActionResult ComputeResults()
        {
            var winner = _electionService.ComputeElectionResult();
            return Ok(winner);
        }

        [HttpGet]
        [Route("is-election-open")]
        public IActionResult IsElectionOpen()
        {
            var isOpen = _electionService.IsElectionOpen();
            return Ok(isOpen);
        }
    }
}
