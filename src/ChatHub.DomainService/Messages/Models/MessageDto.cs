using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService.Messages.Models
{
    public class MessageDto : BaseOutput
    {
        public Guid UserId { get; set; }

        public Guid MessageRoomId { get; set; }

        public string Text { get; set; }

        public DateTime SubmitDateTime { get; set; }
    }
}
