using System;
using System.Collections.Generic;
using System.Linq;
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

        [OneTimeSetUp]
        public void TestSetup()
        {
            _voteRepositoryMock = new Mock<IRepository<Vote>>();

            _userReposiroryMock = new Mock<IRepository<User>>();
            _userReposiroryMock.Setup(m => m.GetById(1)).Returns(new User { Name = "João" });

            _restaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            _restaurantRepositoryMock.Setup(m => m.GetById(1)).Returns(new Restaurant("a", "Fogo de chão", "", 1));
        }

        [TestCase(1, 1)]
        public void CastVote_PassingUserAndRestaurant_ShouldResturnSucces(int user, int restaurant)
        {
            var voteService = new VoteService(_voteRepositoryMock.Object, _userReposiroryMock.Object, _restaurantRepositoryMock.Object);
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsTrue(voteResult.Status);
        }

        [TestCase(1, 1)]
        public void CastVote_PassingUserAndRestaurant_ShouldResturnUserAlreadyVotedError(int user, int restaurant)
        {
            _voteRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Vote>
            {
                new Vote {UserId = 1, RestaurantId = 2, CreationDate = DateTime.Now}
            });

            var voteService = new VoteService(_voteRepositoryMock.Object, _userReposiroryMock.Object, _restaurantRepositoryMock.Object);
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }


        [TestCase(100, 1)]
        public void CastVote_PassingInvalidUserAndRestaurant_ShouldResturnUserNotFoundError(int user, int restaurant)
        {
            var voteService = new VoteService(_voteRepositoryMock.Object, _userReposiroryMock.Object, _restaurantRepositoryMock.Object);
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }


        [TestCase(1, 10)]
        public void CastVote_PassingUserAndInvalidRestaurant_ShouldResturnRestaurantNotFoundError(int user, int restaurant)
        {
            var voteService = new VoteService(_voteRepositoryMock.Object, _userReposiroryMock.Object, _restaurantRepositoryMock.Object);
            var voteResult = voteService.CastVote(new Vote { UserId = user, RestaurantId = restaurant });
            Assert.IsFalse(voteResult.Status);
        }
    }
}