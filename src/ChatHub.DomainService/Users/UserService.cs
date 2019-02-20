using ChatHub.Domain.Users;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.Users.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Users
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly ChatHubEntities dbContext;

        public UserService(ChatHubEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserDto> FindByMobile(string mobile)
        {
            return await dbContext.Users
                                  .Select(c => new UserDto()
                                  {
                                      Id = c.Id,
                                      Mobile = c.Mobile,
                                      Name = c.Name
                                  })
                                  .SingleOrDefaultAsync(c => c.Mobile == mobile);
        }

        protected override User ToEntity(UserDto output)
        {
            return new User()
            {
                Name = output.Name,
                Mobile = output.Mobile
            };
        }

        protected override UserDto ToOutput(User entity)
        {
            return new UserDto()
            {
                Name = entity.Name,
                Mobile = entity.Mobile
            };
        }
    }
}
