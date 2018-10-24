using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using EventFlow.Commands;

namespace CQRS.Domain.EventFlow.Commands
{
    public class IncMagicNumber : Command<Product, ProductId>
    {
        public IncMagicNumber(ProductId aggregateId, int magicNumber) : base(aggregateId)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
