using TheFoodParliament.Domain.Responses;

namespace TheFoodParliament.Domain.Services
{
    public interface IElectionService
    {
        ObjectResponse GetLastWinner();
        bool IsElectionOpen();
        ObjectResponse ComputeElectionResult();
    }
}