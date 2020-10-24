using TheFoodParliament.Domain.Responses;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Domain.Services
{
    public interface IVoteService
    {
        SimpleResponse CastVote(Vote vote);
    }
}