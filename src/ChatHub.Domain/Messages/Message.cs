using ChatHub.Domain.MessageRooms;
using ChatHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Domain.Messages
{
    public class Message : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Text { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("MessageRoomId")]
        public virtual MessageRoom MessageRoom { get; set; }
        public Guid MessageRoomId { get; set; }
    }
}
