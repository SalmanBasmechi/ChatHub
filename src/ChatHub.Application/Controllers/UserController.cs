using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatHub.AppService.AuthenticateModule;
using ChatHub.AppService.LoginModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatHub.Application.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateModule authenticateModule;
        private readonly ILoginModule loginModule;

        public UserController(IAuthenticateModule authenticateModule, ILoginModule loginModule)
        {
            this.authenticateModule = authenticateModule;
            this.loginModule = loginModule;            
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] string mobile)
        {
            await loginModule.LoginAsync(mobile);
            return Ok();
        }

        [HttpDelete, Authorize]
        public IActionResult Logout()
        {
            loginModule.Logout();
            return Ok();
        }
    }
}