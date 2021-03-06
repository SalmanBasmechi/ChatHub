﻿using ChatHub.Data.EFContext;
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

        [HttpPost, ValidateModel, AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            user.Mobile = $"+98{user.Mobile}";

            bool exist = await dbContext.Users.AnyAsync(c => c.Mobile == user.Mobile);

            if (exist)
            {
                return BadRequest("An user is available with this mobile number");
            }

            dbContext.Users.Add(user);

            int result = await dbContext.SaveChangesAsync();

            if (result <= 0)
            {
                return BadRequest();
            }

            await HttpContext.SetAuthCookieAsync(user);
            return Ok();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] string mobile)
        {
            User user = await dbContext.Users.FirstOrDefaultAsync(c => c.Mobile == $"+98{mobile}");

            if (user == null)
            {
                return NotFound();
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
