using System;
using System.Linq;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Responses;

namespace TheFoodParliament.Services
{
    public class VoteService : IVoteService
    {
        private IRepository<Vote> _voteRepository;
        private IRepository<User> _userRepository;
        private IRepository<Restaurant> _restaurantRepository;

        public VoteService(IRepository<Vote> voteRepository,
            IRepository<User> userRepository,
            IRepository<Restaurant> restaurantRepository)
        {
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        public SimpleResponse CastVote(Vote vote)
        {
            var userExist = _userRepository.GetById(vote.UserId);
            if (userExist == null)
                return SimpleResponse.Error("User does not exists");

            var restaurantExists = _restaurantRepository.GetById(vote.RestaurantId);

            if (restaurantExists == null)
                return SimpleResponse.Error("Restaurant does not exists");


            var initialDateTime = DateTime.Parse("00:00");
            var endDateTime = DateTime.Parse("23:59");

            var userAlreadyVoted = _voteRepository.GetAll()
                .Any(v => v.UserId == vote.UserId && v.CreationDate >= initialDateTime && v.CreationDate <= endDateTime);

            if (userAlreadyVoted)
                return SimpleResponse.Error("User already voted today!");

            _voteRepository.Add(vote);

            return SimpleResponse.Success("Vote casted with success!");
        }
    }
}