using ChatHub.Domain.MessageRooms;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.MessageRooms
{
    public class MessageRoomService : Crud<MessageRoom>, IMessageRoomService
    {
        private readonly ChatHubEntities dbContext;

        public MessageRoomService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
