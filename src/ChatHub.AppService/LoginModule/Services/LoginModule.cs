using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatHub.AppService.LoginModule.Models;
using ChatHub.DomainService;
using ChatHub.DomainService.Users.Models;

namespace ChatHub.AppService.LoginModule.Services
{
    public class LoginModule : ILoginModule
    {
        private readonly IDataContext dataContext;

        public LoginModule(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<UserDto> LoginAsync(string mobile)
        {
            UserDto user = await dataContext.Users.FindByMobile(mobile);

            if (user == null)
            {
                user.Name = mobile;
                user.Mobile = mobile;

                dataContext.Users.Create(user);

                await dataContext.SaveChangesAsync();
            }

            return user;
        }

        public void SetAuthCookie(UserClaim userClaim)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
