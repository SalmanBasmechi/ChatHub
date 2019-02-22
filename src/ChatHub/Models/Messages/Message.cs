using ChatHub.Models.MessageRooms;
using ChatHub.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatHub.Models.Messages
{
    public class Message : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public DateTime SubmitDateTime { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("MessageRoomId")]
        public virtual MessageRoom MessageRoom { get; set; }
        public Guid MessageRoomId { get; set; }
    }
}
