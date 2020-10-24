using System.Collections.Generic;
using TheFoodParliament.Entities.Models;

namespace TheFoodParliament.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}