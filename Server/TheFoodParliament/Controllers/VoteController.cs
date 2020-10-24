using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Domain.Services;
using TheFoodParliament.Domain.Responses;

namespace TheFoodParliament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly ILogger<VoteController> _logger;
        private readonly IVoteService _voteService;

        public VoteController(ILogger<VoteController> logger,
            IVoteService voteService)
        {
            _logger = logger;
            _voteService = voteService;
        }

        [HttpPost]
        public ActionResult Post(Vote vote)
        {
            var voteResult = _voteService.CastVote(vote);
            return Created("Vote", voteResult);
        }
    }
}