using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using CQRS.Domain.EventFlow.Events;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.MongoDB.ReadStores.Attributes;
using EventFlow.ReadStores;

namespace CQRS.Domain.EventFlow.ReadModels
{
    [MongoDbCollectionName("ef-products")]
    public class ProductReadModelMongo : IMongoDbReadModel, IAmReadModelFor<Product, ProductId, ProductCreated>, IAmReadModelFor<Product, ProductId, MagicNumberIcremented>
    {
        public string _id { get; set; }
        public long? _version { get; set; }
        public int MagicNumber { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<Product, ProductId, ProductCreated> domainEvent)
        {
            _id = domainEvent.AggregateIdentity.Value;
            MagicNumber = domainEvent.AggregateEvent.MagicNumber;
        }

        public void Apply(IReadModelContext context, IDomainEvent<Product, ProductId, MagicNumberIcremented> domainEvent)
        {
            _id = domainEvent.AggregateIdentity.Value;
            MagicNumber += domainEvent.AggregateEvent.MagicNumber;
        }
    }
}
