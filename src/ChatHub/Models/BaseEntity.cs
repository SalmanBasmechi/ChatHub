using System;
using System.ComponentModel.DataAnnotations;

namespace ChatHub.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
