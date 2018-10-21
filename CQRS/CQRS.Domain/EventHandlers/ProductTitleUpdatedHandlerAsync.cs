using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Events;
using OpenCqrs.Events;

namespace CQRS.Domain.EventHandlers
{
    public class ProductTitleUpdatedHandlerAsync : IEventHandlerAsync<ProductTitleUpdated>
    {
        public async Task HandleAsync(ProductTitleUpdated @event)
        {
            await Task.CompletedTask;

            var model = FakeReadDatabase.Products.Find(x => x.Id == @event.AggregateRootId);
            model.Title = @event.Title;
        }
    }
}
