using TheFoodParliament.Entities.Models;
using TheFoodParliament.Responses;

namespace TheFoodParliament
{
    public interface IElectionService
    {
        bool IsElectionOpen();
        ObjectResponse ComputeElectionResult();
    }
}