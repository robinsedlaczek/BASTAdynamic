using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManagerFrontend.DataModel;

namespace AccountManagerFrontend.BusinessLogic
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);

        Task<List<User>> GetUserRangeAsync(int startId, int range);

        Task<User> CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}