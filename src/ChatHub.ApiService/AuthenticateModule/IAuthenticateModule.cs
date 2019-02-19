﻿using ChatHub.ApiService.AuthenticateModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.ApiService.AuthenticateModule
{
    public interface IAuthenticateModule
    {
        void SetAuthCookie(UserClaim userClaim);

        void ClearAuthCookie();
    }
}
