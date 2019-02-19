using ChatHub.AppService.MessengerModule;
using ChatHub.AppService.MessengerModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatHub.Application.Controllers
{
    [ApiController, Authorize, Route("api/[controller]/[action]")]
    public class MessageRoomController : ControllerBase
    {
        private readonly IMessengerModule messengerModule;

        public MessageRoomController(IMessengerModule messengerModule)
        {
            this.messengerModule = messengerModule;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            IEnumerable<MessageRoomDto> messageRooms = await messengerModule.GetMessageRooms();

            return new JsonResult(messageRooms);
        }

        [HttpPost]
        public async Task<JsonResult> Search([FromBody] string keywork)
        {
            IEnumerable<MessageRoomDto> messageRooms = await messengerModule.SearchMessageRooms(keywork);

            return new JsonResult(messageRooms);
        }
    }
}