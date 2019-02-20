using ChatHub.AppService.LoginModule;
using ChatHub.AppService.MessengerModule;
using ChatHub.DomainService.MessageRooms.Models;
using ChatHub.DomainService.Messages.Models;
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

        public async Task SendMessage(string message, Guid messageRoomId)
        {
            MessageDto messageDto = await messengerModule.InsertMessage(Context.User.GetId(), messageRoomId, message);

            await Clients.Others.SendAsync("OnReceivedMessage", Context.User.GetName(), messageDto);
        }

        public async Task CreateMessageRoom(string name)
        {
            MessageRoomDto messageRoomDto = await messengerModule.InsertMessageRoom(name);

            await Clients.Others.SendAsync("OnMessageRoomCreate", messageRoomDto);
        }
    }
}
