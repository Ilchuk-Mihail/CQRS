using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Domain;

namespace CQRS.Domain.Commands
{
    public class CreateProduct : DomainCommand
    {
        public string Title { get; set; }
    }
}
