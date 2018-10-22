using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.EventFlow.Aggregates;
using CQRS.Domain.EventFlow.Commands;
using CQRS.Domain.EventFlow.Events;
using EventFlow.Commands;

namespace CQRS.Domain.EventFlow.CommandHandlers
{
    public class CreateProductHandler : CommandHandler<Product, ProductId, CreateProduct>
    {
        public override Task ExecuteAsync(Product aggregate, CreateProduct command, CancellationToken cancellationToken)
        {
            aggregate.SetMagicNumer(command.MagicNumber);
            return Task.FromResult(0);
        }
    }
}
