using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
