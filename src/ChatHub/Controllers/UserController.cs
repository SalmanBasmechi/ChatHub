using ChatHub.Data.EFContext;
using ChatHub.Infrastructure;
using ChatHub.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ChatHubEntities dbContext;

        public UserController(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User value)
        {
            User user = await dbContext.Users.SingleOrDefaultAsync(c => c.Mobile == value.Mobile);

            if (user == null)
            {
                user = new User()
                {
                    Mobile = value.Mobile,
                    Name = value.Name
                };

                dbContext.Users.Add(user);

                int result = await dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    return BadRequest();
                }
            }

            await HttpContext.SetAuthCookieAsync(user);
            return Ok();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.ClearAuthCookieAsync();
            return Ok();
        }
    }
}