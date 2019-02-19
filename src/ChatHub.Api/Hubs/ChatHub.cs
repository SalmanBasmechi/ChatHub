using ChatHub.ApiService.MessengerModule;
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
            await Clients.All.SendAsync("OnReceivedMessage", Context.User.Identity.Name, message);
        }
    }
}
