using ChatHub.AppService.AuthenticateModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.AppService.AuthenticateModule
{
    public interface IAuthenticateModule
    {
        void SetAuthCookie(UserClaim userClaim);

        void ClearAuthCookie();
    }
}
