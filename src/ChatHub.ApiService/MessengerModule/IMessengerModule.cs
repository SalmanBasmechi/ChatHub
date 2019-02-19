using ChatHub.ApiService.MessengerModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.ApiService.MessengerModule
{
    public interface IMessengerModule
    {
        Task<MessageDto> InsertMessage(MessageDto value);

        Task<IEnumerable<MessageDto>> SearchMessagesInAllRoom(string keyword);

        Task<IEnumerable<MessageDto>> GetLastMessages(object messageRoomId, object lastMessageId = null);

        Task<MessageRoomDto> InsertMessageRoom(string name);

        Task<IEnumerable<MessageRoomDto>> SearchMessageRooms(string keyword);

        Task<IEnumerable<MessageRoomDto>> GetMessageRooms();
    }
}
