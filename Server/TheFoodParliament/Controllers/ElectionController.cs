using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Services;

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
        [Route("compute-result")]
        public IActionResult GetElectionWinner()
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
