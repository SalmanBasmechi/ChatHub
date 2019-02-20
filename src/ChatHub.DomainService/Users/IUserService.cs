using ChatHub.DomainService.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Users
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<UserDto> FindByMobile(string mobile);
    }
}
