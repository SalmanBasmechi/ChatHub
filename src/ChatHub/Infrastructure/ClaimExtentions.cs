using System;
using System.Security.Claims;

namespace ChatHub.Infrastructure
{
    public static class ClaimExtentions
    {
        public static Guid GetId(this ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public static string GetName(this ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public static string GetMobile(this ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }
    }
}
