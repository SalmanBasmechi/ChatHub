using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.AppService.LoginModule.Models
{
    public class UserClaim
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
    }
}
