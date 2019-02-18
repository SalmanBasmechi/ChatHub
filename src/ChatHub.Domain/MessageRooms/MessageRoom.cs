using ChatHub.Domain.Messages;
using ChatHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Domain.MessageRooms
{
    public class MessageRoom : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(50)]
        public string Name { get; set; }

        [InverseProperty("MessageRoom")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
