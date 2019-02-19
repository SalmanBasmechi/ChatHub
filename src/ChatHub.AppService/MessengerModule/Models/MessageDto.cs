using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.AppService.MessengerModule.Models
{
    public class MessageDto
    {
        public Guid MessageId { get; set; }

        public Guid UserId { get; set; }

        public Guid MessageRoomId { get; set; }

        public string Text { get; set; }

        public DateTime SubmitDateTime { get; set; }
    }
}
