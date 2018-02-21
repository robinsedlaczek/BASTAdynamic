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
    public class UserDetailModel : PageModel
    {
        IUserRepository _users;

        [BindProperty]
        public User UserData {get; set;}

        public UserDetailModel(IUserRepository users) => _users = users;

        public void OnGet()
        {
            var mode = Request.Query.FirstOrDefault(q => q.Key.Equals("mode"));
            if (mode.Value.Equals("new"))
            {
                UserData = new User();
                return;
            }
            var usrId = Request.Query.FirstOrDefault(q => q.Key.Equals("id"));
             
             if (int.TryParse(usrId.Value.ToString(), out int id))
             {
                 UserData = _users.GetUserAsync(id).Result;
             }
        }

        public void OnPost()
        {
            var mode = Request.Query.FirstOrDefault(q => q.Key.Equals("mode"));

            switch(mode.Value.ToString())
            {
                case "new": _users.CreateUserAsync(UserData).Wait();
                break;
                case "edit": _users.UpdateUserAsync(UserData).Wait();
                break;
                case "delete": _users.DeleteUserAsync(UserData).Wait();
                break;
                
            }

            Response.Redirect("/users");
        }

        public async Task<List<User>> Render()
        {

            await _users.CreateUserAsync(new User{
                FirstName = "Theo",
                LastName = "Test",
                Address = "Hinterhof 2",
                Company = ".NET CORP"
            });
            return await _users.GetUserRangeAsync(0, 10);
        }
    }
}
