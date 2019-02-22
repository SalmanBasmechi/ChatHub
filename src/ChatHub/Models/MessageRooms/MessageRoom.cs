using ChatHub.Models.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatHub.Models.MessageRooms
{
    public class MessageRoom : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime SubmitDateTime { get; set; }

        [InverseProperty("MessageRoom")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
