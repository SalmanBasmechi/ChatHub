using ChatHub.AppService.LoginModule.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChatHub.AppService.LoginModule
{
    public static class AuthenticateExtentions
    {
        public static UserClaim GetClaim(this ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public static Guid GetId(this ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public static string GetMobile(this ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }
}
