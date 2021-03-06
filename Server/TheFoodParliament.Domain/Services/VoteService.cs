using System;
using System.Linq;
using TheFoodParliament.Domain.Responses;
using TheFoodParliament.Domain.Wrappers;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;

namespace TheFoodParliament.Domain.Services
{
    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> _voteRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<Election> _electionRepository;
        private readonly IDateTimeWrapper _dateTimeWrapper;

        public VoteService(IRepository<Vote> voteRepository,
            IRepository<User> userRepository,
            IRepository<Restaurant> restaurantRepository,
            IRepository<Election> electionRepository,
            IDateTimeWrapper dateTimeWrapper)
        {
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _electionRepository = electionRepository;
            _restaurantRepository = restaurantRepository;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public SimpleResponse CastVote(Vote vote)
        {
            var isValidVote = this.IsValidVote(vote);

            if (!isValidVote.Status)
                return isValidVote;

            var userAlreadyVoted = this.UserAlreadyVoted(vote);

            if (!userAlreadyVoted.Status)
                return userAlreadyVoted;

            var restaurantAlreadyElected = this.RestaurantAlreadyElected(vote.RestaurantId);

            if (!restaurantAlreadyElected.Status)
                return restaurantAlreadyElected;

            vote.Date = _dateTimeWrapper.Now();

            _voteRepository.Add(vote);

            return SimpleResponse.Success("Vote casted with success!");
        }

        private SimpleResponse IsValidVote(Vote vote)
        {
            var userExist = _userRepository.GetById(vote.UserId);
            if (userExist == null)
                return SimpleResponse.Error("User does not exists");

            var restaurantExists = _restaurantRepository.GetById(vote.RestaurantId);

            if (restaurantExists == null)
                return SimpleResponse.Error("Restaurant does not exists");

            return SimpleResponse.Success("");
        }

        private SimpleResponse UserAlreadyVoted(Vote vote)
        {
            var initialDateTime = _dateTimeWrapper.Parse("00:00");
            var endDateTime = _dateTimeWrapper.Parse("23:59");

            var userAlreadyVoted = _voteRepository.GetAll()
                .Any(v => v.UserId == vote.UserId && v.CreationDate >= initialDateTime && v.CreationDate <= endDateTime);

            if (userAlreadyVoted)
                return SimpleResponse.Error("User already voted today!");

            return SimpleResponse.Success("");
        }

        private SimpleResponse RestaurantAlreadyElected(int restaurantId)
        {
            var currentDay = (int)_dateTimeWrapper.Now().DayOfWeek;
            var firstDayOfWeek = _dateTimeWrapper.Now().AddDays(-currentDay);
            var lastDayOfWeek = _dateTimeWrapper.Now().AddDays(6 - currentDay);

            var hasAlreadyElected = _electionRepository.GetAll()
                .Any(e => e.RestaurantId == restaurantId && e.WinningDate >= firstDayOfWeek && e.WinningDate <= lastDayOfWeek);

            if (hasAlreadyElected)
                return SimpleResponse.Error("Restaurant already elected this week");

            return SimpleResponse.Success("");
        }

        SimpleResponse IVoteService.CastVote(Vote vote)
        {
            throw new NotImplementedException();
        }
    }
}