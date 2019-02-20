using ChatHub.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatHub.DomainService
{
    public abstract class BaseOutput
    {
        public virtual Guid Id { get; set; }
    }
}
