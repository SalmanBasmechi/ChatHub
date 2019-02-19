using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.AppService.AuthenticateModule.Models
{
    public class UserClaim
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
    }
}
