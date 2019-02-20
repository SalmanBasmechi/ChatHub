using ChatHub.AppService.LoginModule.Models;
using ChatHub.DomainService.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.AppService.LoginModule
{
    public interface ILoginModule
    {
        Task<UserDto> LoginAsync(string mobile);

        void SetAuthCookie(UserClaim userClaim);

        void Logout();
    }
}
