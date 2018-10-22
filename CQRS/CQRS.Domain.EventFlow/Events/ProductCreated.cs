using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using EventFlow.Aggregates;

namespace CQRS.Domain.EventFlow.Events
{
    public class ProductCreated : AggregateEvent<Product, ProductId>
    {
        public ProductCreated(int magicNumber)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
