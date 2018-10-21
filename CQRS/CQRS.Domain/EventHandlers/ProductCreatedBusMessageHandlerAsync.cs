using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Events;
using OpenCqrs.Events;

namespace CQRS.Domain.EventHandlers
{
    public class ProductCreatedBusMessageHandlerAsync : IEventHandlerAsync<ProductCreatedBusMessage>
    {
        public async Task HandleAsync(ProductCreatedBusMessage @event)
        {
            await Task.CompletedTask;

            var model = new ProductViewModel
            {
                Id = @event.AggregateRootId,
                Title = @event.Title
            };

            FakeReadDatabase.Products.Add(model);
        }
    }
}
