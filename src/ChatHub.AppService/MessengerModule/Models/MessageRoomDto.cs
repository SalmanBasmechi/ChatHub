using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.AppService.MessengerModule.Models
{
    public class MessageRoomDto
    {
        public Guid MessageRoomId { get; set; }

        public string Name { get; set; }
    }
}
