using ChatHub.Data.EFContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{
    [ApiController, Authorize, Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly ChatHubEntities dbContext;

        public MessageController(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("{messageRoomId:guid}")]
        public async Task<JsonResult> GetAll(Guid messageRoomId)
        {
            var messages = await dbContext.Messages
                                          .Include(c => c.User)
                                          .Where(c => c.MessageRoomId == messageRoomId)
                                          .Select(c => new
                                          {
                                              c.MessageRoomId,
                                              c.UserId,
                                              c.User.Name,
                                              c.SubmitDateTime,
                                              c.Text
                                          })
                                          .OrderBy(c => c.SubmitDateTime)
                                          .ToListAsync();

            return new JsonResult(messages);
        }

        [Route("{messageRoomId:guid}/{page:int}")]
        public async Task<JsonResult> GetAll(Guid messageRoomId, int page)
        {
            var messages = await dbContext.Messages
                                          .Include(c => c.User)
                                          .Where(c => c.MessageRoomId == messageRoomId)
                                          .Skip(page * 50)
                                          .Take(50)
                                          .Select(c => new
                                          {
                                              c.MessageRoomId,
                                              c.UserId,
                                              c.User.Name,
                                              c.SubmitDateTime,
                                              c.Text
                                          })
                                          .OrderBy(c => c.SubmitDateTime)
                                          .ToListAsync();

            return new JsonResult(messages);
        }

        [Route("{keywork}")]
        public async Task<JsonResult> Search(string keywork)
        {
            var messages = await dbContext.Messages
                                          .Include(c => c.User)
                                          .Include(c => c.MessageRoom)
                                          .Where(c => c.Text.Contains(keywork, StringComparison.OrdinalIgnoreCase))
                                          .Select(c => new
                                          {
                                              c.UserId,
                                              c.MessageRoomId,
                                              UserName = c.User.Name,
                                              MessageRoomName = c.MessageRoom.Name,
                                              c.SubmitDateTime,
                                              c.Text
                                          })
                                          .OrderBy(c => c.MessageRoomId)
                                          .OrderBy(c => c.SubmitDateTime)
                                          .ToListAsync();

            return new JsonResult(messages);
        }
    }
}