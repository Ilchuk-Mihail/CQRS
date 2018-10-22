using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Events;
using EventFlow.Aggregates;
using EventFlow.Exceptions;

namespace CQRS.Domain.EventFlow.Aggregates
{
    public class Product : AggregateRoot<Product, ProductId>, IEmit<ProductCreated>
    {
        public string Title { get; private set; }
        public ProductStatus Status { get; private set; }
        private int? _magicNumber;

        public Product(ProductId id) : base(id)
        {
        }


        // Method invoked by our command
        public void SetMagicNumer(int magicNumber)
        {
            if (_magicNumber.HasValue)
                throw DomainError.With("Magic number already set");

            Emit(new ProductCreated(magicNumber));
        }

        // We apply the event as part of the event sourcing system. EventFlow
        // provides several different methods for doing this, e.g. state objects,
        // the Apply method is merely the simplest
        public void Apply(ProductCreated aggregateEvent)
        {
            _magicNumber = aggregateEvent.MagicNumber;
        }
    }
}
