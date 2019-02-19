using ChatHub.DomainService.MessageRooms;
using ChatHub.DomainService.Messages;
using ChatHub.DomainService.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService
{
    public interface IDataContext : IDisposable
    {
        IUserService Users { get; }

        IMessageService Messages { get; }

        IMessageRoomService MessageRooms { get; }

        Task<int> SaveChangesAsync();
    }
}
