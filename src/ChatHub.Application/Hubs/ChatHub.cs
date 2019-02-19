using ChatHub.AppService.AuthenticateModule;
using ChatHub.AppService.MessengerModule;
using ChatHub.AppService.MessengerModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Application.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessengerModule messengerModule;

        public ChatHub(IMessengerModule messengerModule)
        {
            this.messengerModule = messengerModule;
        }

        public async Task SendMessage(string message, Guid roomId)
        {
            MessageDto messageDto = new MessageDto()
            {
                UserId = Context.User.GetId(),
                MessageRoomId = roomId,
                Text = message,
                SubmitDateTime = DateTime.Now
            };

            await messengerModule.InsertMessage(messageDto);

            await Clients.Others.SendAsync("OnReceivedMessage", Context.User.GetName(), messageDto);
        }

        public async Task CreateMessageRoom(string name)
        {
            MessageRoomDto messageRoomDto = await messengerModule.InsertMessageRoom(name);

            await Clients.Others.SendAsync("OnMessageRoomCreate", messageRoomDto);
        }
    }
}
