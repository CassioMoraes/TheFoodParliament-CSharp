using System;
using System.Collections.Generic;
using System.Globalization;
using Moq;
using NUnit.Framework;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;
using TheFoodParliament.Services;
using TheFoodParliament.Wrappers;

namespace TheFoodParliament.Tests
{
    public class ElectionServiceTests
    {
        private Mock<IElectionRepository> _electionRepositoryMock;
        private Mock<IRepository<Vote>> _voteRepositoryMock;
        private Mock<IDateTimeWrapper> _dateTimeWrapperMock;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _electionRepositoryMock = new Mock<IElectionRepository>();

            _dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            _dateTimeWrapperMock.Setup(m => m.Now()).Returns(DateTime.Parse("01-01-2000 12:00:00 PM"));
            _dateTimeWrapperMock.Setup(m => m.Parse(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string time, string format) => { return DateTime.ParseExact(time, format, CultureInfo.InvariantCulture); });

            _voteRepositoryMock = new Mock<IRepository<Vote>>();
            _voteRepositoryMock.Setup(m => m.GetAll()).Returns(
                new List<Vote>
                {
                    new Vote {UserId = 1, RestaurantId = 1, Date = DateTime.Parse("01-01-2000 09:00:00")},
                    new Vote {UserId = 2, RestaurantId = 2, Date = DateTime.Parse("01-01-2000 09:00:00")},
                    new Vote {UserId = 3, RestaurantId = 1, Date = DateTime.Parse("01-01-2000 09:00:00")},
                    new Vote {UserId = 4, RestaurantId = 3, Date = DateTime.Parse("01-01-2000 09:00:00")},
                    new Vote {UserId = 4, RestaurantId = 3, Date = DateTime.Parse("02-01-2000 09:00:00")},
                    new Vote {UserId = 3, RestaurantId = 1, Date = DateTime.Parse("02-01-2000 09:00:00")}
                }
            );
        }

        [TestCase(1)]
        public void ComputeElection_PassingWinnerId_ShouldReturnElectionResult(int expectedWinnerId)
        {
            var electionService = new ElectionService(_electionRepositoryMock.Object,
                _voteRepositoryMock.Object,
                _dateTimeWrapperMock.Object);
            var winner = electionService.ComputeElectionResult();

            Assert.AreEqual(expectedWinnerId, (winner.Result as Election).RestaurantId);
        }

        [TestCase(1)]
        public void ComputeElection_PassingWinnerId_ShouldWhenDrawReturnTheFirstOne(int expectedWinnerId)
        {
            var electionService = new ElectionService(_electionRepositoryMock.Object,
                _voteRepositoryMock.Object,
                _dateTimeWrapperMock.Object);
            var winner = electionService.ComputeElectionResult();

            Assert.AreEqual(expectedWinnerId, (winner.Result as Election).RestaurantId);
        }

        [TestCase("10:00")]
        [TestCase("08:00")]
        [TestCase("11:59")]
        public void IsElectionOpen_ShouldReturnTrue(string currentDate)
        {
            var dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            dateTimeWrapperMock.Setup(m => m.Now()).Returns(DateTime.Parse(currentDate));
            dateTimeWrapperMock.Setup(m => m.Parse(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string time, string format) => { return DateTime.ParseExact(time, format, CultureInfo.InvariantCulture); });

            var electionService = new ElectionService(_electionRepositoryMock.Object,
                _voteRepositoryMock.Object,
                dateTimeWrapperMock.Object);
            var isElectionOpen = electionService.IsElectionOpen();

            Assert.IsTrue(isElectionOpen);
        }

        [TestCase("07:59")]
        [TestCase("12:00")]
        public void IsElectionOpen_ShouldReturnFalse(string currentDate)
        {
            var dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            dateTimeWrapperMock.Setup(m => m.Now()).Returns(DateTime.Parse(currentDate));
            dateTimeWrapperMock.Setup(m => m.Parse(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string time, string format) => { return DateTime.ParseExact(time, format, CultureInfo.InvariantCulture); });

            var electionService = new ElectionService(_electionRepositoryMock.Object,
                _voteRepositoryMock.Object,
                dateTimeWrapperMock.Object);
            var isElectionOpen = electionService.IsElectionOpen();

            Assert.IsFalse(isElectionOpen);
        }
    }
}