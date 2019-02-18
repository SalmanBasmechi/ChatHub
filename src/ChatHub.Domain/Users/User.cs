using ChatHub.Domain.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Domain.Users
{
    public class User : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(50)]
        public string Name { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
