using TheFoodParliament.Entities.Models;
using TheFoodParliament.Responses;

namespace TheFoodParliament.Services
{
    public interface IVoteService
    {
        SimpleResponse CastVote(Vote vote);
    }
}