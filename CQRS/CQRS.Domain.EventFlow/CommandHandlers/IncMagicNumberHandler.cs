using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.EventFlow.Aggregates;
using CQRS.Domain.EventFlow.Commands;
using EventFlow.Commands;

namespace CQRS.Domain.EventFlow.CommandHandlers
{
    public class IncMagicNumberHandler : CommandHandler<Product, ProductId, IncMagicNumber>
    {
        public override Task ExecuteAsync(Product aggregate, IncMagicNumber command, CancellationToken cancellationToken)
        {
            aggregate.IncMagicNumer(command.MagicNumber);
            return Task.FromResult(0);
        }
    }
}
