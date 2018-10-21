using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Domain;

namespace CQRS.Domain.Events
{
    public class ProductPublished : DomainEvent
    {
        public ProductStatus Status = ProductStatus.Published;
    }
}
