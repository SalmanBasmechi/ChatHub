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
                                                  c.Name
                                              })
                                              .OrderBy(c => c.Name)
                                              .ToListAsync();

            return new JsonResult(messageRooms);
        }

        [Route("{keyword}")]
        public async Task<JsonResult> Search(string keyword)
        {
            var messageRooms = await dbContext.MessageRooms
                                              .Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                              .Select(c => new
                                              {
                                                  c.Id,
                                                  c.Name
                                              })
                                              .OrderBy(c => c.Name)
                                              .ToListAsync();

            return new JsonResult(messageRooms);
        }
    }
}