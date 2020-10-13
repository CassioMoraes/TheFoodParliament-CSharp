using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Services;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Tests.Services
{
    public class VoteServiceTests
    {
        private Mock<IRepository<Vote>> _voteRepositoryMock;
        private Mock<IRepository<User>> _userReposiroryMock;
        private Mock<IRepository<Restaurant>> _restaurantRepositoryMock;
        private Mock<IRepository<Election>> _electionRepositoryMock;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _voteRepositoryMock = new Mock<IRepository<Vote>>();

            _userReposiroryMock = new Mock<IRepository<User>>();
            _userReposiroryMock.Setup(m => m.GetById(1)).Returns(new User { Name = "João" });

            _restaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            _restaurantRepositoryMock.Setup(m => m.GetById(1)).Returns(new Restaurant("a", "Fogo de chão", "", 1));

            _electionRepositoryMock = new Mock<IRepository<Election>>();
        }

        [TestCase(1, 1)]
        public void CastVote_PassingUserAndRestaurant_ShouldResturnSucces(int user, int restaurant)
        {
            var voteService = new VoteService(_voteRepositoryMock.Object,
                _userReposiroryMock.Object,
                _restaurantRepositoryMock.Object,
                _electionRepositoryMock.Object,
                new DateTimeWrapper());
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsTrue(voteResult.Status);
        }

        [TestCase(1, 1)]
        public void CastVote_PassingUserAndRestaurant_ShouldResturnUserAlreadyVotedError(int user, int restaurant)
        {
            var localVoteRepositoryMock = new Mock<IRepository<Vote>>();
            localVoteRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Vote>
            {
                new Vote {UserId = 1, RestaurantId = 2, CreationDate = DateTime.Now}
            });

            var voteService = new VoteService(localVoteRepositoryMock.Object,
                _userReposiroryMock.Object,
                _restaurantRepositoryMock.Object,
                _electionRepositoryMock.Object,
                new DateTimeWrapper());
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }

        [TestCase(100, 1)]
        public void CastVote_PassingInvalidUserAndRestaurant_ShouldResturnUserNotFoundError(int user, int restaurant)
        {
            var voteService = new VoteService(_voteRepositoryMock.Object,
                _userReposiroryMock.Object,
                _restaurantRepositoryMock.Object,
                _electionRepositoryMock.Object,
                new DateTimeWrapper());
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }

        [TestCase(1, 1, "12/10/2020", "14/10/2020")]
        public void CastVote_PassingUserAndRestaurantAlreadyElected_ShouldResturnRestaurantAlreadyElectedError(
            int user, int restaurant, string winningDate, string currentDate)
        {
            var elected = new Election { Votes = 1, RestaurantId = 1, WinningDate = DateTime.Parse(winningDate) };
            var localElectionRepositoryMock = new Mock<IRepository<Election>>();
            localElectionRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Election> { elected });

            var dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            dateTimeWrapperMock.Setup(m => m.Now()).Returns(DateTime.Parse(currentDate));

            var voteService = new VoteService(_voteRepositoryMock.Object,
                _userReposiroryMock.Object,
                _restaurantRepositoryMock.Object,
                localElectionRepositoryMock.Object,
                dateTimeWrapperMock.Object);
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }
    }
}