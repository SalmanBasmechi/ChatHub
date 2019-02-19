using ChatHub.Domain.Messages;
using ChatHub.DomainService.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.Messages
{
    public interface IMessageService : ICrud<Message>
    {

    }
}
