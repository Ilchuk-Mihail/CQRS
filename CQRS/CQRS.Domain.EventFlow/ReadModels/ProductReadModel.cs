using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using CQRS.Domain.EventFlow.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace CQRS.Domain.EventFlow.ReadModels
{
    public class ProductReadModel : IReadModel, IAmReadModelFor<Product, ProductId, ProductCreated>
    {
        public int MagicNumber { get; private set; }

        public void Apply(IReadModelContext context, IDomainEvent<Product, ProductId, ProductCreated> domainEvent)
        {
            MagicNumber = domainEvent.AggregateEvent.MagicNumber;
        }
    }
}
