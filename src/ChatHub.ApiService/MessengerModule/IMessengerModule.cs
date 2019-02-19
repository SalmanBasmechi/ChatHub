using ChatHub.ApiService.MessengerModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.ApiService.MessengerModule
{
    public interface IMessengerModule
    {
        Task InsertMessage(MessageDto value);

        Task<IList<MessageDto>> SearchMessagesInAllRoom(string keyword);

        Task<IList<MessageRoomDto>> GetLastMessages(object messageRoomId, object lastMessageId = null);

        Task InsertMessageRoom(MessageRoomDto value);

        Task<IList<MessageRoomDto>> SearchMessageRooms(string keyword);

        Task<IList<MessageRoomDto>> GetMessageRooms();
    }
}
