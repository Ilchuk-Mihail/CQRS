using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.EventFlow.Aggregates;
using EventFlow.Commands;

namespace CQRS.Domain.EventFlow.Commands
{
    public class CreateProduct : Command<Product, ProductId>
    {
        public CreateProduct(ProductId aggregateId, int magicNumber) : base(aggregateId)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
