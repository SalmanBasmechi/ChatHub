using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatHub.AppService.MessengerModule;
using ChatHub.DomainService.Messages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatHub.Application.Controllers
{
    [ApiController, Authorize, Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessengerModule messengerModule;

        public MessageController(IMessengerModule messengerModule)
        {
            this.messengerModule = messengerModule;
        }

        [HttpGet, Route("{messageRoomId:guid}")]
        public async Task<JsonResult> GetAll(Guid messageRoomId)
        {
            IList<MessageDto> messages = await messengerModule.GetLastMessages(messageRoomId);

            return new JsonResult(messages);
        }

        [HttpGet, Route("{messageRoomId:guid}/{lastMessageId:guid}")]
        public async Task<JsonResult> GetAll(Guid messageRoomId, Guid lastMessageId)
        {
            IList<MessageDto> messages = await messengerModule.GetLastMessages(messageRoomId, lastMessageId);

            return new JsonResult(messages);
        }

        [HttpPost]
        public async Task<JsonResult> Search([FromBody] string keywork)
        {
            IList<MessageDto> messages = await messengerModule.SearchMessagesInAllRoom(keywork);

            return new JsonResult(messages);
        }
    }
}