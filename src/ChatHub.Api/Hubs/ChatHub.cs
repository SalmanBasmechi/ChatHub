using ChatHub.ApiService.AuthenticateModule;
using ChatHub.ApiService.MessengerModule;
using ChatHub.ApiService.MessengerModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Api.Hubs
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

            await Clients.All.SendAsync("OnReceivedMessage", Context.User.GetName(), messageDto);
        }

        public async Task CreateMessageRoom(string name)
        {
            MessageRoomDto messageRoomDto = await messengerModule.InsertMessageRoom(name);

            await Clients.All.SendAsync("OnMessageRoomCreate", messageRoomDto);
        }
    }
}
