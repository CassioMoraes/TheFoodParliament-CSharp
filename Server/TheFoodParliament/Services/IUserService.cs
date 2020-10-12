using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}