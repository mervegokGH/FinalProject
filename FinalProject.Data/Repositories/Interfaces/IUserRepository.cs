using FinalProject.Domain.Users;
using System.Collections.Generic;

namespace FinalProject.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsersByUsername(string Username);
    }
}
