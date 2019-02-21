using ChatHub.Models.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatHub.Models.Users
{
    public class User : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Mobile { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
