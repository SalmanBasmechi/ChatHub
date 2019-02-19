using ChatHub.Domain.Messages;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.Messages
{
    public class MessageService : Crud<Message>, IMessageService
    {
        private readonly ChatHubEntities dbContext;

        public MessageService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
