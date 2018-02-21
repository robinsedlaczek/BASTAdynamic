using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AccountManagerFrontend.DataModel;

namespace AccountManagerFrontend.BusinessLogic
{
    #pragma warning disable 1998
    public class UserRepositoryMock : IUserRepository
    {
        private static List<User> _mockUsers = new List<User>();
        private static int _id = 1;
        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = _id++;
            _mockUsers.Add(user);
            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            _mockUsers.RemoveAll(mu => mu.Id == user.Id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            //Debug.WriteLine($"############ Requested user id => {id}");
            return _mockUsers.FirstOrDefault(mu => mu.Id == id);
        }

        public async Task<List<User>> GetUserRangeAsync(int startId, int range)
        {
            return _mockUsers
                .OrderBy(mu => mu.Id)
                .Where(mu => mu.Id > startId)
                .Take(range)
                .ToList();
        }

        public async Task UpdateUserAsync(User user)
        {
            var usr = await this.GetUserAsync(user.Id);
            usr.FirstName = user.FirstName;
            usr.LastName = user.LastName;
            usr.Address = user.Address;
            usr.Company = user.Company;
        }
    }
    #pragma warning restore 1998
}