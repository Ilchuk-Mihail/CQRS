using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Domain;

namespace CQRS.Domain.Commands
{
    public class PublishProduct : DomainCommand
    {
        public Guid ProductId { get; set; }
    }
}
