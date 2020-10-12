using System.Collections.Generic;
using TheFoodParliament.Entities.Models;
using TheFoodParliament.Infrastructure.Repositories;

namespace TheFoodParliament.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
    }
}