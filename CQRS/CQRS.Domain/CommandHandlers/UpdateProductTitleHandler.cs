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
    public class UpdateProductTitleHandler : ICommandHandlerWithDomainEventsAsync<UpdateProductTitle>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductTitleHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IDomainEvent>> HandleAsync(UpdateProductTitle command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
                throw new ApplicationException("Product not found.");

            product.UpdateTitle(command.Title);

            return product.Events;
        }
    }
}
