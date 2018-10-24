using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using EventFlow.Aggregates;

namespace CQRS.Domain.EventFlow.Events
{
    public class MagicNumberIcremented : AggregateEvent<Product, ProductId>
    {
        public MagicNumberIcremented(int magicNumber)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
