using FinalProject.Data.Repositories.Interfaces;
using FinalProject.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Data.Repositories.Concretes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }

        public List<User> GetUsersByUsername(string userName)
        {
            return _context.Users
                .Where(x => x.Username.Equals(userName, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
    }
}
