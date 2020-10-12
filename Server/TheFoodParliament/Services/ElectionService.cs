using System.Linq;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Responses;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Services
{
    public class ElectionService : IElectionService
    {
        private IRepository<Election> _electionRepository;
        private IRepository<Vote> _voteRepository;
        private IDateTimeWrapper _dateTimeWrapper;
        public ElectionService(IRepository<Election> electionRepository,
            IRepository<Vote> voteRepository,
            IDateTimeWrapper dateTimeWrapper)
        {
            _electionRepository = electionRepository;
            _voteRepository = voteRepository;
            _dateTimeWrapper = dateTimeWrapper;
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
                WinnerId = mostVoted.Key,
                WinningDate = _dateTimeWrapper.Now(),
                Votes = mostVoted.Count()
            };

            _electionRepository.Add(election);

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