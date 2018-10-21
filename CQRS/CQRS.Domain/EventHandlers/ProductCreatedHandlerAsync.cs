using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Events;
using OpenCqrs.Events;

namespace CQRS.Domain.EventHandlers
{
    public class ProductCreatedHandlerAsync : IEventHandlerAsync<ProductCreated>
    {
        public async Task HandleAsync(ProductCreated @event)
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
