using ChatHub.DomainService.Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Messages
{
    public interface IMessageService : IBaseService<MessageDto>
    {
        Task<IList<MessageDto>> GetAllMessages(Guid messageRoomId);

        Task<IList<MessageDto>> GetAllMessages(Guid messageRoomId, Guid lastMessageId);

        Task<IList<MessageDto>> SearchInAllRooms(string keywork);
    }
}
