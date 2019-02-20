using ChatHub.DomainService.MessageRooms.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService.MessageRooms
{
    public interface IMessageRoomService : IBaseService<MessageRoomDto>
    {
        Task<IList<MessageRoomDto>> GetAllMessageRooms();

        Task<IList<MessageRoomDto>> SearchInAllRooms(string keywork);
    }
}
