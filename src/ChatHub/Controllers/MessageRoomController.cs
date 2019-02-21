using ChatHub.Data.EFContext;
using ChatHub.Models.MessageRooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{
    [ApiController, Authorize, Route("api/[controller]/[action]")]
    public class MessageRoomController : ControllerBase
    {
        private readonly ChatHubEntities dbContext;

        public MessageRoomController(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<JsonResult> GetAll()
        {
            var messageRooms = await dbContext.MessageRooms
                                              .Select(c => new
                                              {
                                                  c.Id,
                                                  c.Name,
                                                  c.SubmitDateTime
                                              })
                                              .ToListAsync();

            return new JsonResult(messageRooms);
        }

        [HttpPost]
        public async Task<JsonResult> Search([FromBody] string keywork)
        {
            var messageRooms = await dbContext.MessageRooms
                                              .Where(c => c.Name.Contains(keywork, StringComparison.OrdinalIgnoreCase))
                                              .Select(c => new
                                              {
                                                  c.Id,
                                                  c.Name,
                                                  c.SubmitDateTime
                                              })
                                              .ToListAsync();

            return new JsonResult(messageRooms);
        }
    }
}