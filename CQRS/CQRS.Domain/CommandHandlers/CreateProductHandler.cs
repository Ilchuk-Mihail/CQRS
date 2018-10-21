using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Aggregates;
using CQRS.Domain.Commands;
using OpenCqrs.Commands;
using OpenCqrs.Domain;

namespace CQRS.Domain.CommandHandlers
{
    public class CreateProductHandler : ICommandHandlerWithDomainEventsAsync<CreateProduct>
    {
        public async Task<IEnumerable<IDomainEvent>> HandleAsync(CreateProduct command)
        {
            await Task.CompletedTask;

            var product = new Product(command.AggregateRootId, command.Title);

            return product.Events;
        }
    }
}
