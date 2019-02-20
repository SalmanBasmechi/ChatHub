using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatHub.DomainService;
using ChatHub.DomainService.MessageRooms.Models;
using ChatHub.DomainService.Messages.Models;

namespace ChatHub.AppService.MessengerModule.Services
{
    public class MessengerModule : IMessengerModule
    {
        private readonly IDataContext dataContext;

        public MessengerModule(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IList<MessageDto>> GetLastMessages(Guid messageRoomId)
        {
            return await dataContext.Messages.GetAllMessages(messageRoomId);
        }

        public async Task<IList<MessageDto>> GetLastMessages(Guid messageRoomId, Guid lastMessageId)
        {
            return await dataContext.Messages.GetAllMessages(messageRoomId, lastMessageId);
        }

        public async Task<IList<MessageRoomDto>> GetMessageRooms()
        {
            return await dataContext.MessageRooms.GetAllMessageRooms();
        }

        public async Task<MessageDto> InsertMessage(Guid userId, Guid messageRoomId, string text)
        {
            MessageDto message = new MessageDto()
            {
                UserId = userId,
                MessageRoomId = messageRoomId,
                Text = text,
                SubmitDateTime = DateTime.Now
            };

            dataContext.Messages.Create(message);

            await dataContext.SaveChangesAsync();

            return new MessageDto()
            {
                Id = message.Id,
                MessageRoomId = message.MessageRoomId,
                UserId = message.UserId,
                SubmitDateTime = message.SubmitDateTime,
                Text = message.Text
            };
        }

        public async Task<MessageRoomDto> InsertMessageRoom(string name)
        {
            MessageRoomDto messageRoom = new MessageRoomDto()
            {
                Name = name,
            };

            dataContext.MessageRooms.Create(messageRoom);

            await dataContext.SaveChangesAsync();

            return new MessageRoomDto()
            {
                Id = messageRoom.Id,
                Name = messageRoom.Name
            };
        }

        public async Task<IList<MessageRoomDto>> SearchMessageRooms(string keyword)
        {
            return await dataContext.MessageRooms.SearchInAllRooms(keyword);
        }

        public async Task<IList<MessageDto>> SearchMessagesInAllRoom(string keyword)
        {
            return await dataContext.Messages.SearchInAllRooms(keyword);
        }
    }
}
