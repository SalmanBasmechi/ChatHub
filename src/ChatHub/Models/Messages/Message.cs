using ChatHub.Models.MessageRooms;
using ChatHub.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Models.Messages
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public DateTime SubmitDateTime { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("MessageRoomId")]
        public virtual MessageRoom MessageRoom { get; set; }
        public Guid MessageRoomId { get; set; }
    }
}
