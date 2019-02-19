using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.MessageRooms;
using ChatHub.DomainService.Messages;
using ChatHub.DomainService.Users;

namespace ChatHub.DomainService
{
    public class DataContext : IDataContext
    {
        private readonly ChatHubEntities dbContext;

        public DataContext(ChatHubEntities dbContext,
                           IUserService userRepository,
                           IMessageService messageRepository,
                           IMessageRoomService messageRoomRepository)
        {
            this.dbContext = dbContext;

            Users = userRepository;
            Messages = messageRepository;
            MessageRooms = messageRoomRepository;
        }

        public IUserService Users { get; }

        public IMessageService Messages { get; }

        public IMessageRoomService MessageRooms { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
