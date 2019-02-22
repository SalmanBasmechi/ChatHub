using ChatHub.Data.EFContext;
using ChatHub.Infrastructure;
using ChatHub.Models.MessageRooms;
using ChatHub.Models.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatHub.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ChatHubEntities dbContext;

        public ChatHub(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task JoinMessageRoom(Guid messageRoomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, messageRoomId.ToString());
        }

        public async Task LeaveMessageRoom(Guid messageRoomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, messageRoomId.ToString());
        }

        public async Task SendMessage(string text, Guid messageRoomId)
        {
            var message = dbContext.Messages.Add(new Message()
            {
                UserId = Context.User.GetId(),
                MessageRoomId = messageRoomId,
                SubmitDateTime = DateTime.Now,
                Text = text
            }).Entity;

            int result = await dbContext.SaveChangesAsync();

            if (result > 0)
            {
                await Clients.Group(messageRoomId.ToString()).SendAsync("onReceiveMessage", Context.User.GetName(), message);
            }
        }

        public async Task CreateMessageRoom(string name)
        {
            var messageRoom = dbContext.MessageRooms.Add(new MessageRoom()
            {
                Name = name,
                SubmitDateTime = DateTime.Now
            });

            int result = await dbContext.SaveChangesAsync();

            if(result > 0)
            {
                await Clients.All.SendAsync("onCreateMessageRoom", messageRoom);
            }
        }
    }
}
