using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatHub.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}
