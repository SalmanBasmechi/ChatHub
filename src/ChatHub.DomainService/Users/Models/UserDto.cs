using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.Users.Models
{
    public class UserDto : BaseOutput
    {
        public string Name { get; set; }

        public string Mobile { get; set; }
    }
}
