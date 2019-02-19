using ChatHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.ApiService.LoginModule
{
    public interface ILoginModule
    {
        Task<User> LoginAsync(string mobile);

        void Logout();
    }
}
