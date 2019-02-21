using ChatHub.Models.Messages;
using ChatHub.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Models.MessageRooms
{
    public class MessageRoom : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime SubmitDateTime { get; set; } = DateTime.Now;

        [InverseProperty("MessageRoom")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
