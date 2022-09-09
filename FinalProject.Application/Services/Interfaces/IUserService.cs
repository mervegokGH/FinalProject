using FinalProject.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(User user);
        IEnumerable<User> List();
        Task Delete(int id);
        Task ChangeStatus(int id);
        Task Edit(User user);
        User Get(int id);
    }
}
