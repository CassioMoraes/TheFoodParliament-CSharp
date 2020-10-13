using System.Linq;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Responses;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Services
{
    public class ElectionService : IElectionService
    {
        private IElectionRepository _electionRepository;
        private IRepository<Vote> _voteRepository;
        private IDateTimeWrapper _dateTimeWrapper;
        public ElectionService(IElectionRepository electionRepository,
            IRepository<Vote> voteRepository,
            IDateTimeWrapper dateTimeWrapper)
        {
            _electionRepository = electionRepository;
            _voteRepository = voteRepository;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public ObjectResponse GetLastWinner()
        {
            var lastWinner = _electionRepository.GetAllWithRestaurants()
                .OrderByDescending(e => e.WinningDate)
                .FirstOrDefault();

            if (lastWinner == null)
                return ObjectResponse.Error("There is no winner so far!", null);

            return ObjectResponse.Success("The Last winner", lastWinner);
        }

        public ObjectResponse ComputeElectionResult()
        {
            if (this.IsElectionOpen())
                return ObjectResponse.Error("Election is still open", null);

            var currentDay = _dateTimeWrapper.Now();

            var votes = _voteRepository.GetAll()
                .Where(v => v.Date.DayOfYear == currentDay.DayOfYear && v.Date.Year == currentDay.Year);

            if (votes.Count() == 0)
                return ObjectResponse.Error("There is no votes for this election", null);

            var mostVoted = votes.GroupBy(v => v.RestaurantId)
                .OrderByDescending(v => v.Count())
                .FirstOrDefault();

            var election = new Election
            {
                RestaurantId = mostVoted.Key,
                WinningDate = _dateTimeWrapper.Now(),
                Votes = mostVoted.Count()
            };

            (_electionRepository as GenericRepository<Election>).Add(election);

            return ObjectResponse.Success("", election);
        }

        public bool IsElectionOpen()
        {
            var openingElection = _dateTimeWrapper.Parse("08:00:00", "HH:mm:ss").TimeOfDay;
            var closingElection = _dateTimeWrapper.Parse("12:00:00", "HH:mm:ss").TimeOfDay;
            var currentTime = _dateTimeWrapper.Now().TimeOfDay;

            if (currentTime >= openingElection && currentTime < closingElection)
                return true;

            return false;
        }
    }
}