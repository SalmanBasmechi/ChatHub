using ChatHub.Data.EFContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ChatHubEntities dbContext;

        public UserController(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] string mobile)
        {
            return RedirectToAction("App", "Home");
        }

        [Authorize]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}