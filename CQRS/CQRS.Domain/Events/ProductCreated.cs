using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Domain;

namespace CQRS.Domain.Events
{
    public class ProductCreated : DomainEvent
    {
        public string Title { get; set; }
        public ProductStatus Status { get; set; }
    }
}
