using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagerFrontend.BusinessLogic;
using AccountManagerFrontend.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountManagerFrontend.Pages
{
    public class UsersModel : PageModel
    {
        IUserRepository _users;

        public UsersModel(IUserRepository users) => _users = users;

        public void OnGet()
        {
             
        }

        public async Task<List<User>> Render()
        {
            
            return await _users.GetUserRangeAsync(0, 10);
        }
    }
}
