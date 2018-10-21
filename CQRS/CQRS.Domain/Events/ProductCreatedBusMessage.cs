using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Bus;
using OpenCqrs.Domain;

namespace CQRS.Domain.Events
{
    public class ProductCreatedBusMessage : DomainEvent, IBusQueueMessage
    {
        public string Title { get; set; }
        public ProductStatus Status { get; set; }

        public DateTime? ScheduledEnqueueTimeUtc { get; set; }
        public string QueueName { get; set; } = "product-created";
    }
}
