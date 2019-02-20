using ChatHub.DomainService.MessageRooms.Models;
using ChatHub.DomainService.Messages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.AppService.MessengerModule
{
    public interface IMessengerModule
    {
        Task<MessageDto> InsertMessage(Guid userId, Guid messageRoomId, string text);

        Task<IList<MessageDto>> SearchMessagesInAllRoom(string keyword);

        Task<IList<MessageDto>> GetLastMessages(Guid messageRoomId);

        Task<IList<MessageDto>> GetLastMessages(Guid messageRoomId, Guid lastMessageId);        

        Task<MessageRoomDto> InsertMessageRoom(string name);

        Task<IList<MessageRoomDto>> SearchMessageRooms(string keyword);

        Task<IList<MessageRoomDto>> GetMessageRooms();
    }
}
