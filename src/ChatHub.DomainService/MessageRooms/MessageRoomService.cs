using ChatHub.Domain.MessageRooms;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.MessageRooms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MessageRoomDto = ChatHub.DomainService.MessageRooms.Models.MessageRoomDto;

namespace ChatHub.DomainService.MessageRooms
{
    public class MessageRoomService : BaseEFService<MessageRoom, MessageRoomDto>, IMessageRoomService
    {
        private readonly ChatHubEntities dbContext;

        public MessageRoomService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<MessageRoomDto>> GetAllMessageRooms()
        {
            return await dbContext.MessageRooms
                                  .Select(c => new MessageRoomDto()
                                  {
                                      Id = c.Id,
                                      Name = c.Name
                                  })
                                  .ToListAsync();
        }

        public async Task<IList<MessageRoomDto>> SearchInAllRooms(string keywork)
        {
            return await dbContext.MessageRooms
                                  .Where(c => c.Name.Contains(keywork, StringComparison.OrdinalIgnoreCase))
                                  .Select(c => new MessageRoomDto()
                                  {
                                      Id = c.Id,
                                      Name = c.Name
                                  })
                                  .ToListAsync();
        }

        protected override MessageRoom ToEntity(MessageRoomDto output)
        {
            return new MessageRoom()
            {
                Id = output.Id,
                Name = output.Name
            };
        }

        protected override MessageRoomDto ToOutput(MessageRoom entity)
        {
            return new MessageRoomDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
