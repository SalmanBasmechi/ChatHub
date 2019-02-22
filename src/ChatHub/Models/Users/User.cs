using ChatHub.Models.Messages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatHub.Models.Users
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, Column(TypeName = "varchar(15)")]
        public string Mobile { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
