using ChatHub.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatHub.Infrastructure
{
    public static class AuthExtentions
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

        public static async Task SetAuthCookieAsync(this HttpContext httpContext, User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim("Mobile", user.Mobile)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMonths(6)
            };

            await httpContext.Request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
        }

        public static async Task ClearAuthCookieAsync(this HttpContext httpContext)
        {
            await httpContext.Request.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
