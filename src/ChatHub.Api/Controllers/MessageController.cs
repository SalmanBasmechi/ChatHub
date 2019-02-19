using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatHub.ApiService.MessengerModule;
using ChatHub.ApiService.MessengerModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatHub.Api.Controllers
{
    [ApiController, Authorize, Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessengerModule messengerModule;

        public MessageController(IMessengerModule messengerModule)
        {
            this.messengerModule = messengerModule;
        }
        
        [HttpGet, Route("{messageRoomId:guid}/{lastMessageId?:guid}")]
        public async Task<JsonResult> GetAll(Guid messageRoomId, Guid? lastMessageId)
        {
            IEnumerable<MessageDto> messages = await messengerModule.GetLastMessages(messageRoomId, lastMessageId);

            return new JsonResult(messages);
        }

        [HttpPost]
        public async Task<JsonResult> Search([FromBody] string keywork)
        {
            IEnumerable<MessageDto> messages = await messengerModule.SearchMessagesInAllRoom(keywork);

            return new JsonResult(messages);
        }
    }
}