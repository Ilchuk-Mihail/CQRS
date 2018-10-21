using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Domain;

namespace CQRS.Domain.Commands
{
    public class UpdateProductTitle : DomainCommand
    {
        public string Title { get; set; }
    }
}
