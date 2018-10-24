using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.EventFlow.Events;
using EventFlow.Aggregates;
using EventFlow.Exceptions;
using EventFlow.Snapshots;
using EventFlow.Snapshots.Strategies;

namespace CQRS.Domain.EventFlow.Aggregates
{
    public class Product : AggregateRoot<Product, ProductId>, IEmit<ProductCreated>, IEmit<MagicNumberIcremented>
       // SnapshotAggregateRoot<Product, ProductId, ProductAggregateSnapshot>

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
            //if (_magicNumber.HasValue)
            //    throw DomainError.With("Magic number already set");

            Emit(new ProductCreated(magicNumber));
        }

        // Method invoked by our command
        public void IncMagicNumer(int magicNumber)
        {
            //if (_magicNumber.HasValue)
            //    throw DomainError.With("Magic number already set");

            Emit(new MagicNumberIcremented(magicNumber));
        }

        // We apply the event as part of the event sourcing system. EventFlow
        // provides several different methods for doing this, e.g. state objects,
        // the Apply method is merely the simplest
        public void Apply(ProductCreated aggregateEvent)
        {
            _magicNumber = aggregateEvent.MagicNumber;
        }

        public void Apply(MagicNumberIcremented aggregateEvent)
        {
            _magicNumber += aggregateEvent.MagicNumber;
        }

        //public Product(ProductId id, ISnapshotStrategy snapshotStrategy) : base(id,
        //    SnapshotEveryFewVersionsStrategy.With(10))
        //{
        //   // _paymentProviderFactory = paymentProviderFactory;
        //  //  Register(_magicNumber);
        //}

        //protected override Task<ProductAggregateSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override Task LoadSnapshotAsync(ProductAggregateSnapshot snapshot, ISnapshotMetadata metadata,
        //    CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
