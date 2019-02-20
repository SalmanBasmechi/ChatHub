using ChatHub.Domain.Messages;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.Messages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Messages
{
    public class MessageService : BaseService<Message, MessageDto>, IMessageService
    {
        private readonly ChatHubEntities dbContext;

        public MessageService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<MessageDto>> GetAllMessages(Guid messageRoomId)
        {
            return await dbContext.Messages
                                  .Where(c => c.Id == messageRoomId)
                                  .Select(c => new MessageDto()
                                  {
                                      Id = c.Id,
                                      MessageRoomId = c.MessageRoomId,
                                      UserId = c.UserId,
                                      SubmitDateTime = c.SubmitDateTime,
                                      Text = c.Text
                                  })
                                  .ToListAsync();
        }

        public async Task<IList<MessageDto>> GetAllMessages(Guid messageRoomId, Guid lastMessageId)
        {
            return await dbContext.Messages
                                  .Where(c => c.Id == messageRoomId)
                                  .Select(c => new MessageDto()
                                  {
                                      Id = c.Id,
                                      MessageRoomId = c.MessageRoomId,
                                      UserId = c.UserId,
                                      SubmitDateTime = c.SubmitDateTime,
                                      Text = c.Text
                                  })
                                  .ToListAsync();
        }

        public async Task<IList<MessageDto>> SearchInAllRooms(string keywork)
        {
            return await dbContext.Messages
                                  .Where(c => c.Text.Contains(keywork, StringComparison.OrdinalIgnoreCase))
                                  .Select(c => new MessageDto()
                                  {
                                      Id = c.Id,
                                      MessageRoomId = c.MessageRoomId,
                                      UserId = c.UserId,
                                      SubmitDateTime = c.SubmitDateTime,
                                      Text = c.Text
                                  })
                                  .ToListAsync();
        }

        protected override Message ToEntity(MessageDto output)
        {
            return new Message()
            {
                UserId = output.UserId,
                MessageRoomId = output.MessageRoomId,
                Text = output.Text
            };
        }

        protected override MessageDto ToOutput(Message entity)
        {
            return new MessageDto()
            {
                Id = entity.Id,
                MessageRoomId = entity.MessageRoomId,
                UserId = entity.UserId,
                SubmitDateTime = entity.SubmitDateTime,
                Text = entity.Text,
            };
        }
    }
}
