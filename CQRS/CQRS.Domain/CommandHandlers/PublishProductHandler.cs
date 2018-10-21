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
    public class PublishProductHandler : ICommandHandlerWithDomainEventsAsync<PublishProduct>
    {
        private readonly IRepository<Product> _repository;

        public PublishProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IDomainEvent>> HandleAsync(PublishProduct command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
                throw new ApplicationException("Product not found.");

            product.Publish();

            return product.Events;
        }
    }
}
