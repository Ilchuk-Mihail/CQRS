using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Events;
using OpenCqrs.Events;

namespace CQRS.Domain.EventHandlers
{
    public class ProductPublishedHandler : IEventHandlerAsync<ProductPublished>
    {
        public async Task HandleAsync(ProductPublished @event)
        {
            await Task.CompletedTask;

            var model = FakeReadDatabase.Products.Find(x => x.Id == @event.AggregateRootId);
            model.Status = @event.Status;
        }
    }
}
