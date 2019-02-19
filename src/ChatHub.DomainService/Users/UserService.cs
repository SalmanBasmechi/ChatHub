using ChatHub.Domain.Users;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.Users
{
    public class UserService : Crud<User>, IUserService
    {
        private readonly ChatHubEntities dbContext;

        public UserService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
