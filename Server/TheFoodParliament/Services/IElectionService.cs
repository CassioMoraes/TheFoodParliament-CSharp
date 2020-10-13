using TheFoodParliament.Responses;

namespace TheFoodParliament
{
    public interface IElectionService
    {
        ObjectResponse GetLastWinner();
        bool IsElectionOpen();
        ObjectResponse ComputeElectionResult();
    }
}